using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WorkersAccounting.Entities;

namespace WorkersAccounting.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<WorkerViewModel> _models;

    [ObservableProperty]
    private WorkerViewModel _selectedModel;

    public MainViewModel(ObservableCollection<WorkerViewModel> models)
    {
        Models = models;
        models.CollectionChanged += (sender, args) => OnPropertyChanged(nameof(Models));
    }

    public MainViewModel() : this(new ObservableCollection<WorkerViewModel>())
    {
    }

    public MainViewModel(IEnumerable<WorkerViewModel> workers)
        : this(new ObservableCollection<WorkerViewModel>(workers))
    {
    }
    
    public MainViewModel(IEnumerable<Worker> workers)
        : this(workers.Select(w => new WorkerViewModel(w)))
    {
    }

    [RelayCommand]
    public void Remove(WorkerViewModel model)
    {
        Models.Remove(model);
    }

    [RelayCommand]
    public void Add(WorkerViewModel model)
    {
        Models.Add(model);
    }

    [RelayCommand]
    public void Create()
    {
        var worker = GenerateTemplateWorker();
        var viewModel = new WorkerViewModel(worker);
        Add(viewModel);
    }

    private static Worker GenerateTemplateWorker()
    {
        return new Worker()
        {
            FirstName = "FirstName",
            HourTimeWorking = 0,
            BirthDay = DateTime.Today,
            Description = string.Empty,
            LastName = "LastName"
        };
    }
    
    
}
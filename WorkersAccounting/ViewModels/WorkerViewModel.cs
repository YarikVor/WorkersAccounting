using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WorkersAccounting.Entities;

namespace WorkersAccounting.ViewModels;

public partial class WorkerViewModel : ObservableObject
{
    [ObservableProperty]
    private Worker _model;

    public WorkerViewModel() : this(new Worker())
    {
    }

    public WorkerViewModel(Worker model)
    {
        _model = model;
    }

    public string FirstName
    {
        get => Model.FirstName;
        set
        {
            SetProperty(Model.FirstName, value, Model,
                (originModel, newValue) => { originModel.FirstName = newValue; });
        }
    }

    public string LastName
    {
        get => Model.LastName;
        set
        {
            SetProperty(Model.LastName, value, Model, (originModel, newValue) => { originModel.LastName = newValue; });
        }
    }

    public int HourTimeWorking
    {
        get => Model.HourTimeWorking;
        set
        {
            SetProperty(Model.HourTimeWorking, value, Model,
                (originModel, newValue) => originModel.HourTimeWorking = newValue);
        }
    }

    public DateTime Birthday
    {
        get => Model.BirthDay;
        set => SetProperty(Model.BirthDay, value, Model,
            (originModel, newValue) => originModel.BirthDay = newValue);
    }

    public string? Description
    {
        get => Model.Description;
        set => SetProperty(Model.Description, value, Model,
            (originModel, newValue) => originModel.Description = newValue);
    }

    [RelayCommand]
    public void Save()
    {
        Model.FirstName = FirstName;

        OnPropertyChanged(nameof(Model));
    }
}
namespace models{


interface ISmartDevice {

    string Name {get;}
    void TurnOn();
    void TurnOff();
    void ShowStatus();

}

}

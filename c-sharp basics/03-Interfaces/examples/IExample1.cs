namespace examples ;



interface IRun {

    void run();
}

interface IJump {

    void jump();
}

class Player : IRun, IJump{

    public void run(){
        Console.WriteLine("Player runs");
    }

    public void jump(){
        Console.WriteLine("Player jumps");
    }
}


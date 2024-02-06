using System;

class Platform
{
    public void baseplatform()
    {
        Console.WriteLine("              Platform is ready              ");
    }
}

class Engine
{
    public void coreEngine()
    {
        Console.WriteLine("              Core Engine of car in ready              ");
    }

}

class Body
{
    public void boadyApplied()
    {
        Console.WriteLine("              Body applied on the car              ");
    }
}

class PaintCar
{
    public void paintCarReady()
    {
        Console.WriteLine("              Car is painted and done with the final touch              ");
    }
}

class CarFacade
{
    private Platform _platform;
    private Engine _engine; 
    private Body _body;
    private PaintCar _paintCar;

    public CarFacade()
    {
        _platform = new Platform();
        _engine = new Engine();
        _body = new Body();  
        _paintCar = new PaintCar();
    }

    public void manufactureCar()
    {
        Console.WriteLine("              Sir, Your Car is Dilvered              ");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("------------------------------------Behind the scenes -----------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        _platform.baseplatform();
        _engine.coreEngine();
        _body.boadyApplied();
        _paintCar.paintCarReady();
    }
}

class Client
{
    static void Main(String[] args)
    {
        CarFacade carFacade = new CarFacade();
        carFacade.manufactureCar();
    }
}



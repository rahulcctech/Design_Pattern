using System;

interface IShape
{
    void Draw();
}
class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("This is  Circle");
    }
}

class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("This is  Square");
    }
}
/*interface IShapeFactory
{
    IShape CreateShape();
}*/

/*class CircleFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Circle();
    }
}

class SquareFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Square();
    }
}*/

class Factory
{
    public IShape shape = null;

    public IShape getInstance(string shapeType)
    {
        if(shapeType == "circle")
            shape = new Circle();
        else if (shapeType == "square")
            shape = new Square();

        return shape;

    }
}

class Program
{
    static void Main()
    {
        /*IShapeFactory circleFactory = new CircleFactory();
        IShape circle = circleFactory.CreateShape();
        circle.Draw();

        IShapeFactory squareFactory = new SquareFactory();
        IShape square = squareFactory.CreateShape();*/

        IShape shape = null;
        Factory factory = new Factory();
        shape = factory.getInstance("circle");
        shape.Draw();
        shape = factory.getInstance("square");
        shape.Draw();

    }
}



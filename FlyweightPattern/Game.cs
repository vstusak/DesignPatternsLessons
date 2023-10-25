using System.Drawing;
using FlyweightPattern;

public class Game
{
    List<MovingParticle> _particles = new List<MovingParticle>();

    public void initialization()
    {
        /* naive implementation
        var particle = new Particle(Color.Blue);
        var redParticle = new Particle(Color.Red);
        for (var i = 1; i < 10000; i++)
        {
            //_particles.Add(new Particle());
            _particles.Add(new MovingParticle(
                new Point(2, 2*i),
                i,
                i-656,
                particle));
        }
        for (var i = 1; i < 10000; i++)
        {
            //_particles.Add(new Particle());
            _particles.Add(new MovingParticle(
                new Point(2, 2 * i),
                i,
                i - 656,
                redParticle));
        }
        */

        var movingParticleFactory = MovingParticleFactory.GetInstance();

        for (var i = 1; i < 10000; i++)
        {
            //_particles.Add(new Particle());
            _particles.Add(movingParticleFactory.GetMovingParticle(
                new Point(2, 2 * i),
                i,
                i - 656,
                Color.Red));
        }
        
    }
}

//singleton + factory
public class MovingParticleFactory
{
    private static MovingParticleFactory _instance;

    private MovingParticleFactory()
    {
        
    }

    public static MovingParticleFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new MovingParticleFactory();
        }

        return _instance;
    }

    private readonly Dictionary<Color, Particle> _particles = new ();
    
    public MovingParticle GetMovingParticle(Point point, int vector, int speed, Color color)

    {
        var movingParticle = new MovingParticle(
            point,
            vector,
            speed,
            GetColorParticle(color)
            );

        return movingParticle;
    }

    private Particle GetColorParticle(Color color)
    {
        if (!_particles.ContainsKey(color))
        {
            _particles.Add(color, new Particle(color));
        }
        return _particles[color];
    }
}
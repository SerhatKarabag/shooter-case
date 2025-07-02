using System.Collections.Generic;
using System.Linq;

public class PatternBuilder
{
    readonly Shooter _shooter;

    public PatternBuilder(Shooter shooter) => _shooter = shooter;

    public IShootingPattern Build(IEnumerable<PowerUpConfig> configs)
    {
        IOrderedEnumerable<PowerUpConfig> ordered = configs.OrderBy(c => c.priority);
        IShootingPattern pattern = new SingleShotPattern();

        foreach (PowerUpConfig cfg in ordered)
        {
            foreach (ShootingEffect eff in cfg.effects)
                pattern = DecoratorFactory.Wrap(pattern, eff, _shooter);
        }
        return pattern;
    }
}
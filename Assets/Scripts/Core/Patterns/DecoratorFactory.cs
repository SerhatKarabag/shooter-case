public static class DecoratorFactory
{
    public static IShootingPattern Wrap(
        IShootingPattern current,
        ShootingEffect effect,
        Shooter shooter)
    {
        return effect.kind switch
        {
            EffectKind.Spread => new SpreadDecorator(current),
            EffectKind.Double => new DoubleDecorator(current),

            EffectKind.SpeedMul
                => new StatModifierDecorator(current, speedMul: effect.value),

            _ => current
        };
    }
}
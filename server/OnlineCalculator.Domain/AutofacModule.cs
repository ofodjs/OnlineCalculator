using Autofac;
using OnlineCalculator.Domain.Providers;
using OnlineCalculator.Domain.Services;

namespace OnlineCalculator.Domain
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MathExpressionProvider>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<CalculatorService>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
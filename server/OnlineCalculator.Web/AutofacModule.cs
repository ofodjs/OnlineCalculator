using Autofac;
using OnlineCalculator.Web.Models;
using OnlineCalculator.Web.Validators;

namespace OnlineCalculator.Web
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CalculationRequestValidator>().As<IValidator<CalculationRequest>>().SingleInstance();
        }
    }
}
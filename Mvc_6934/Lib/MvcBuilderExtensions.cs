using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Reflection;

namespace Lib
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddEmbeddedViews(this IMvcBuilder services, Assembly assembly)
        {
            var optionsSetup = new Action<RazorViewEngineOptions>(options =>
            {
                var ns = assembly.GetName().Name;

                options.FileProviders.Add(new EmbeddedFileProvider(assembly, ns));
                
                var previous = options.CompilationCallback;
                options.CompilationCallback = context =>
                {
                    previous?.Invoke(context);

                    context.Compilation = context.Compilation.AddReferences(
                        MetadataReference.CreateFromFile(assembly.Location));
                }; 

            });

            return services.AddRazorOptions(optionsSetup);
        }
    }
}

using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using HarfBuzzSharp;
using Test1Avalonia.ViewModels;

namespace Test1Avalonia
{
    public class ViewLocator : IDataTemplate
    {

        public Control? Build(object? param)
        {
            if (param is null)
                return null;

            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            //var a = 1 + 2 * 3;
            
            //int VarBegin = a + 1;Console.WriteLine(VarBegin);
            return data is ViewModelBase;
        }
    }
}
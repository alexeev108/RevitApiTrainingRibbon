using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitApiTrainingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "RevitApiTraining";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Users\alex206\Desktop\RevitApiTrainingUI";

            var panel = application.CreateRibbonPanel(tabName, "Трубы");

            var button = new PushButtonData("Система", "Смена системы труб",
                Path.Combine(utilsFolderPath, "RevitApiTrainingUI.dll"),
                "RevitApiTrainingUI.Main");

            Uri uriImage = new Uri(@"C:\Users\alex206\Desktop\Курсы\ИТМО. Автоматизация информационного поделирования\Модуль 5\RevitApiTrainingRibbon\RevitApiTrainingRibbon\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button.LargeImage = largeImage;

            panel.AddItem(button);

            return Result.Succeeded;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesClient.WindowManagers
{
    class ResizeListViewColums
    {
        public void SetMinColumsWidth(MainWindow mw)
        {
            if(mw.gvcPicture.ActualWidth < 200)
                mw.gvcPicture.Width = 200;
            if (mw.gvcTitle.ActualWidth < 100)
                mw.gvcTitle.Width = 100;
            if (mw.gvcPrepareTime.ActualWidth < 120)
                mw.gvcPrepareTime.Width = 120;
            if (mw.gvcIngredients.ActualWidth < 110)
                mw.gvcIngredients.Width = 110;
        }
    }
}

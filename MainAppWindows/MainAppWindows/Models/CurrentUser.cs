using MainAppWindows.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAppWindows.Models
{
    public static class CurrentUser
    {
        private static bool isInitialized = false;
        public static Andelshaver CurrentAndelshaver { get; private set; }

        public static void Initialize(Andelshaver currentAndelshaver)
        {
            if (isInitialized == true) return;

            CurrentAndelshaver = currentAndelshaver;
            CurrentAndelshaver.Lejligheder = OverallHandler.GetAndelshaversLejligheder(currentAndelshaver.Andelshaver_ID);

            isInitialized = true;
        }
    }
}

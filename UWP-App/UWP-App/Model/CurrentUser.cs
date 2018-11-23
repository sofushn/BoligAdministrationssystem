using System;
using System.Threading.Tasks;
using UWP_App.Persistency;

namespace UWP_App.Model
{
    public static class CurrentUser
    {
        private static Andelshaver _user;
        public static Andelshaver User
        {
            get
            {
                if (!IsInitialized)
                {
                    //throw new Exception("User is not initialized. CurrentUser.InitializeAsync() must be called first.");
                }
                return _user;
            }
        }

        public static bool IsInitialized { get; private set; }
        public static IPersistency Persistency { get; private set; }

        public static async Task Initialize(int andelshaverID, IPersistency persistency)
        {
            Persistency = persistency;
            // if already initialized just return.
            if (IsInitialized)
                return;

            // Gets a user with specified ID
            _user = await Persistency.GetAndelshaverAsync(andelshaverID);

            // Gets users kontrakter
            // No need the get all the contracts unless the user requests it
            if(Persistency.GetType() == typeof(TempTestData))
                _user.Kontrakter = await Persistency.GetAndelshaversKontrakterAsync(_user);

            // Gets users lejligheder
            _user.Lejligheder = await Persistency.GetAndelshaversLejlighederAsync(_user);

            // Gets faldstammer and vinduer for each lejlighed
            foreach (Lejlighed lejlighed in _user.Lejligheder)
            {
                //Move to a class that handels all user loading/data fetching from db
                lejlighed.Faldstammer = await Persistency.GetLejlighedsFaldstammerAsync(lejlighed);
                lejlighed.Vinduer = await Persistency.GetLejlighedsVinduerAsync(lejlighed);
            }

            IsInitialized = true;
        }
    }
}
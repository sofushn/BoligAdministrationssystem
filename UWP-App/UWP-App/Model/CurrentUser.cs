using System;
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
                    throw new Exception("User is not initialized. CurrentUser.Initialize() must be called first.");
                }
                return _user;
            }
        }

        public static bool IsInitialized { get; private set; }

        public static void Initialize(int andelshaverID, IRetrievePersistency retriever)
        {
            // if already initialized just return.
            if (IsInitialized)
                return;

            // Gets a user with specified ID
            _user = retriever.GetAndelshaver(andelshaverID);
            // Gets users kontrakter
            _user.Kontrakter = retriever.GetAndelshaversKontrakter(_user);
            // Gets users lejligheder
            _user.Lejligheder = retriever.GetAndelshaversLejligheder(_user);

            IsInitialized = true;
        }
    }
}
﻿using Firebase.Auth;

namespace CleanProject.Classes
{
    class User
    {
        public FirebaseAuthLink Auth { get; set; }
        public string Environment { get; set; }

        public User(FirebaseAuthLink auth, string environment)
        {
            Auth = auth;
            Environment = environment;
        }
    }
}

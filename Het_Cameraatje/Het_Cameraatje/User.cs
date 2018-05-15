using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Het_Cameraatje
{
    public class User
    {
        
        public FirebaseAuthLink Auth { get; set; }
        public bool School { get; set; }

        public User(FirebaseAuthLink auth, bool enviroment)
        {
            Auth = auth;
            School = enviroment;
        }
    }
}

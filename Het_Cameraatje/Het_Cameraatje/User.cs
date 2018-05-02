using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Het_Cameraatje
{
    class User
    {
        public int UserId { get; set; }
        public FirebaseAuthLink Auth { get; set; }
        public bool IsTeacher { get; set; }
    }
}

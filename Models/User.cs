using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tournament_user_score_tracker

{
    public class User
    {
        // primary key
        // id is a special name. any class/model with a property called 'id
        // will automatically get a primary key field in the database of the given type
        public int id { get; set; }
    }
}

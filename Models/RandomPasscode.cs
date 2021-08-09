using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RandomPasscodeGenerator.Models
{
  public class RandomPasscode 
  {
    public string Passcode {get; set;}
    public int Count {get; set;}
  }

}
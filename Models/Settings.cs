using System;

namespace AngularNetCore.Models
{
  public class Settings
  {
    public class Flow
    {
      public int Id { get; set; }
      public String Name { get; set; }
      public String[] SubFlows { get; set; }
    }

    public int Id { get; set; }
    public String Email { get; set; }
    public Flow [] Flows { get; set; }
  }
}

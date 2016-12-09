﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensions
{
  public static class CustomContains
  {
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
      return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
    }
  }
}

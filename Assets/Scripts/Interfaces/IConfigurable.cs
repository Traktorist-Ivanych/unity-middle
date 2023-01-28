using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfigurable
{
    public IConfiguration Configuration { get; set; }

    public void LoadConfiguration(IConfiguration config);
}

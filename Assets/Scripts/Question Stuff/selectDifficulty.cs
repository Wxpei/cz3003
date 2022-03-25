using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectDifficulty : MonoBehaviour
{
 public Text TextBox;
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("easy");
        items.Add("normal");
        items.Add("hard");
        
        foreach(var item in items){
            dropdown.options.Add(new Dropdown.OptionData() {text = item});
        }
        DropDownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropDownItemSelected(dropdown);});
    }

    void DropDownItemSelected(Dropdown dropdown){
        int index = dropdown.value;
        TextBox.text = dropdown.options[index].text;
    }
}

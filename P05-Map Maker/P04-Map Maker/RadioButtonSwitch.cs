using System;
using System.Windows.Forms;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: RadioButtonSwitch 
/// </summary>
class RadioButtonSwitch : RadioButton {
    #region Fields

    public static int Active { get; set; }

    public int ID { get; set; }

    #endregion
    
    protected override void OnClick(EventArgs e) {
        base.OnClick(e);

        if ( this.Checked) {
            Active = this.ID;
        }

    }

    protected override void OnCheckedChanged(EventArgs e) {
        base.OnCheckedChanged(e);

        //Console.WriteLine("Rawr");
        
    }

    protected override void OnPaint( PaintEventArgs pe ) {
        base.OnPaint( pe );
    }

}


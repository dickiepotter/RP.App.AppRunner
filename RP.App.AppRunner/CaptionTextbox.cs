#region Imports

using System.Windows;
using System.Windows.Controls;

#endregion

namespace CaptionTextbox
{
  public class CaptionTextbox : TextBox
  {
    #region Static Variables

    public static readonly DependencyProperty CaptionProperty =
      DependencyProperty.Register("Caption", typeof (string), typeof (CaptionTextbox));

    public static readonly DependencyProperty HasTextProperty =
      DependencyProperty.Register("HasText", typeof (bool), typeof (CaptionTextbox));

    #endregion

    #region Constructors and Destructors

    static CaptionTextbox()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof (CaptionTextbox), new FrameworkPropertyMetadata(typeof (CaptionTextbox)));
    }

    #endregion

    #region Properties

    public string Caption
    {
      get { return (string) GetValue(CaptionProperty); }
      set { SetValue(CaptionProperty, value); }
    }

    public bool HasText
    {
      get { return (bool) GetValue(HasTextProperty); }
      set { SetValue(HasTextProperty, value); }
    }

    #endregion

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
      base.OnTextChanged(e);
      HasText = Text.Length != 0;
    }
  }
}
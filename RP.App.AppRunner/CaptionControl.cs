#region Imports

using System.Windows;
using System.Windows.Controls;

#endregion

namespace RPUtil.Controls
{
  public class CaptionControl : ContentControl
  {
    #region Static Variables

    public static readonly DependencyProperty CaptionProperty =
      DependencyProperty.Register("Caption", typeof (string), typeof (CaptionControl));

    public static readonly DependencyProperty CaptionDockProperty =
      DependencyProperty.Register("CaptionDock", typeof(Dock), typeof(CaptionControl), new FrameworkPropertyMetadata(Dock.Left, FrameworkPropertyMetadataOptions.AffectsMeasure));

    public static readonly DependencyProperty CaptionAlignmentProperty =
      DependencyProperty.Register("CaptionAlignment", typeof(TextAlignment), typeof(CaptionControl));

    #endregion

    #region Constructors and Destructors

    static CaptionControl()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof (CaptionControl), new FrameworkPropertyMetadata(typeof (CaptionControl)));
    }

    #endregion

    #region Properties

    public string Caption
    {
      get { return (string) GetValue(CaptionProperty); }
      set { SetValue(CaptionProperty, value); }
    }

    public Dock CaptionDock
    {
      get { return (Dock)GetValue(CaptionDockProperty); }
      set { SetValue(CaptionDockProperty, value); }
    }

    public TextAlignment CaptionAlignment
    {
      get { return (TextAlignment)GetValue(CaptionAlignmentProperty); }
      set { SetValue(CaptionAlignmentProperty, value); }
    }

    #endregion
  }
}
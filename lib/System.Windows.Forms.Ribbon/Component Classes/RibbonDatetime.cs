// *********************************
// Message from Original Author:
//
// 2008 Jose Menendez Poo
// Please give me credit if you use this code. It's all I ask.
// Contact me for more info: menendezpoo@gmail.com
// *********************************
//
// Original project from http://ribbon.codeplex.com/
// Continue to support and maintain by http://officeribbon.codeplex.com/

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public class RibbonDatetime
    : RibbonItem
    {
        #region Fields
        private const int spacing = 3;

        internal DateTimePicker _actualPicker;

        internal bool _removingTxt;

        internal bool _labelVisible;

        internal bool _imageVisible;

        internal Rectangle _labelBounds;

        internal Rectangle _imageBounds;

        internal int _textboxWidth;

        internal int _labelWidth;

        internal Rectangle _textBoxBounds;

        internal DateTime _textBoxText;

        internal bool _AllowTextEdit = true;

        private string _formatString = "dd/MM/yyyy";


        DateTimePickerFormat _format = DateTimePickerFormat.Short;

        /// <summary>
        /// Set to true when using a Combobox to inhibit mouse cursor from flickering as this class and Combobox 
        /// fight for control of the cursor.
        /// </summary>
        internal bool _disableTextboxCursor = false;
        #endregion
        #region Events
        /// <summary>
        /// Raised when the <see cref="TextBoxText"/> property value has changed
        /// </summary>
        public event EventHandler TextBoxTextChanged;

        public event KeyPressEventHandler PickerKeyPress;

        public event KeyEventHandler PickerKeyDown;

        public event KeyEventHandler PickerKeyUp;

        public event EventHandler PickerValidating;

        public event EventHandler PickerValidated;
        #endregion
        #region Ctor
        public RibbonDatetime()
        {
            _textboxWidth = 100;
            _textBoxText = DateTime.Now;
        }
        #endregion
        #region Props
        /// <summary>
        /// Gets or sets if the textbox allows editing
        /// </summary>
        [Description("Allow Test Edit")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AllowTextEdit
        {
            get => _AllowTextEdit;
            set
            {
                _AllowTextEdit = value;
                if (Canvas != null) { Canvas.Cursor = AllowTextEdit ? Cursors.IBeam : Cursors.Default; }
            }
        }

        //
        // Summary:
        //     Gets or sets the character used to mask characters of a password in a single-line
        //     System.Windows.Forms.Picker control.
        //
        // Returns:
        //     The character used to mask characters entered in a single-line System.Windows.Forms.Picker
        //     control. Set the value of this property to 0 (character value) if you do
        //     not want the control to mask characters as they are typed. Equals 0 (character
        //     value) by default.

        [Category("Behavior")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public DateTimePickerFormat Format
        {
            get => _format;
            set
            {
                _format = value;

                if (_actualPicker != null)
                {
                    _actualPicker.Format = _format;
                }
            }
        }


        [Category("Behavior")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public string FormatString
        {
            get => _formatString;
            set
            {
                _formatString = value;

                if (_actualPicker != null)
                {
                    _actualPicker.Value = _textBoxText;
                }
            }
        }


        /// <summary>
        /// Gets or sets the text on the textbox
        /// </summary>
        [Category("Appearance")]
        [Description("Text on the textbox")]
        public DateTime TextBoxText
        {
            get => _textBoxText;
            set
            {
                _textBoxText = value;
                if (_actualPicker != null)
                {
                    _actualPicker.Value = _textBoxText;
                }
                OnTextChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the bounds of the text on the textbox
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Rectangle TextBoxTextBounds => PickerBounds;

        /// <summary>
        /// Gets the bounds of the image
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ImageBounds => _imageBounds;

        /// <summary>
        /// Gets the bounds of the label that is shown next to the textbox
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Rectangle LabelBounds => _labelBounds;

        /// <summary>
        /// Gets a value indicating if the image is currenlty visible
        /// </summary>
        [Category("Appearance")]
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ImageVisible => _imageVisible;

        /// <summary>
        /// Gets a value indicating if the label is currently visible
        /// </summary>
        [Category("Appearance")]
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LabelVisible => _labelVisible;

        /// <summary>
        /// Gets the bounds of the text
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Rectangle PickerBounds => _textBoxBounds;

        /// <summary>
        /// Gets a value indicating if user is currently editing the text of the textbox
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Editing => _actualPicker != null;

        /// <summary>
        /// Gets or sets the width of the textbox
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(100)]
        public int PickerWidth
        {
            get => _textboxWidth;
            set
            {
                _textboxWidth = value;
                NotifyOwnerRegionsChanged();
            }
        }

        /// <summary>
        /// Gets or sets the width of the Label. Enter zero to auto size based on contents.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(0)]
        public int LabelWidth
        {
            get => _labelWidth;
            set
            {
                _labelWidth = value;
                NotifyOwnerRegionsChanged();
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Starts editing the text and focuses the Picker
        /// </summary>
        public void StartEdit()
        {
            //if (!Enabled) return;
            PlaceActualPicker();

            //_actualPicker.SelectAll();
            _actualPicker.Focus();

        }

        /// <summary>
        /// Ends the editing of the textbox
        /// </summary>
        public void EndEdit()
        {
            RemoveActualPicker();
        }

        /// <summary>
        /// Places the Actual Picker on the owner so user can edit the text
        /// </summary>
        protected void PlaceActualPicker()
        {
            _actualPicker = new DateTimePicker();

            _actualPicker.Format = DateTimePickerFormat.Short;

            InitPicker(_actualPicker);

            _actualPicker.ValueChanged += _actualPicker_ValueChanged;
            _actualPicker.KeyDown += _actualPicker_KeyDown;
            _actualPicker.KeyUp += _actualPicker_KeyUp;
            _actualPicker.KeyPress += _actualPicker_KeyPress;
            _actualPicker.LostFocus += _actualPicker_LostFocus;
            _actualPicker.VisibleChanged += _actualPicker_VisibleChanged;
            _actualPicker.Validating += _actualPicker_Validating;
            _actualPicker.Validated += _actualPicker_Validated;



            _actualPicker.Visible = true;
            //_actualPicker.AcceptsTab = true;
            Canvas.Controls.Add(_actualPicker);
            Owner.ActivePicker = this;
        }

        public void _actualPicker_VisibleChanged(object sender, EventArgs e)
        {
            if (!(sender as DateTimePicker).Visible && !_removingTxt)
            {
                RemoveActualPicker();
            }
        }

        /// <summary>
        /// Removes the actual Picker that edits the text
        /// </summary>
        protected void RemoveActualPicker()
        {
            if (_actualPicker == null || _removingTxt)
            {
                return;
            }
            _removingTxt = true;

            TextBoxText = _actualPicker.Value;
            _actualPicker.Visible = false;
            if (_actualPicker.Parent != null)
            {
                _actualPicker.Parent.Controls.Remove(_actualPicker);
            }
            _actualPicker.Dispose();
            _actualPicker = null;

            RedrawItem();
            _removingTxt = false;
            Owner.ActivePicker = null;
        }

        /// <summary>
        /// Initializes the texbox that edits the text
        /// </summary>
        /// <param name="t"></param>
        protected virtual void InitPicker(DateTimePicker t)
        {
            t.Value = TextBoxText;
            //t.BorderStyle = BorderStyle.None;
            t.Width = PickerBounds.Width - 2;

            t.Location = new Point(
                PickerBounds.Left + 2,
                Bounds.Top + (Bounds.Height - t.Height) / 2);
        }

        /// <summary>
        /// Handles the LostFocus event of the actual Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _actualPicker_LostFocus(object sender, EventArgs e)
        {
            RemoveActualPicker();
        }

        /// <summary>
        /// Handles the KeyDown event of the actual Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _actualPicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (PickerKeyDown != null)
            {
                PickerKeyDown(this, e);
            }

            if (e.KeyCode == Keys.Return ||
                e.KeyCode == Keys.Enter ||
                e.KeyCode == Keys.Escape)
            {
                RemoveActualPicker();
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the actual Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _actualPicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (PickerKeyUp != null)
            {
                PickerKeyUp(this, e);
            }

            if (e.KeyCode == Keys.Return ||
                e.KeyCode == Keys.Enter ||
                e.KeyCode == Keys.Escape)
            {
                RemoveActualPicker();
            }
        }


        /// <summary>
        /// Handles the KeyPress event of the actual Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _actualPicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            if (PickerKeyPress != null)
            {
                PickerKeyPress(this, e);
            }

            //bool next = false;
            //RibbonItem nextItem = this;

            //foreach (var item in this.OwnerPanel.GetItems())
            //{

            //    if (item == this)
            //    {
            //        next = true;
            //    }
            //    else if (next)
            //    {
            //        nextItem = item;
            //        break;
            //    }
            //}

            //if (nextItem == this)
            //{
            //    var nextTab = this.OwnerPanel.OwnerTab;
            //    var nextFoundTab = false;

            //    foreach (var tab in this.OwnerPanel.OwnerTab.Owner.Tabs)
            //    {
            //        if (tab == this.OwnerPanel.OwnerTab)
            //        {
            //            nextFoundTab = true;
            //        }
            //        else if (nextFoundTab)
            //        {
            //            nextTab = tab;
            //            break;
            //        }
            //    }

            //    if (nextTab == this.OwnerPanel.OwnerTab)
            //    {
            //        nextTab.Owner.OrbSelected = true;
            //        nextTab.Owner.ShowOrbDropDown();
            //    }
            //    else
            //    {
            //        nextTab.Owner.ActiveTab = nextTab;
            //    }

            //}
            //else
            //{
            //    nextItem.SetSelected(true);

            //}
        }

        /// <summary>
        /// Handles the Validating event of the actual Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _actualPicker_Validating(object sender, CancelEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            if (PickerValidating != null)
            {
                PickerValidating(this, e);
            }
        }

        /// <summary>
        /// Handles the Validated event of the actual Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _actualPicker_Validated(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            if (PickerValidated != null)
            {
                PickerValidated(this, e);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the actual Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _actualPicker_ValueChanged(object sender, EventArgs e)
        {
            //Text = (sender as Picker).Text;
            {
                //TextBoxText = (sender as DateTimePicker).Value;
            }
        }

        /// <summary>
        /// Measures the suposed height of the textobx
        /// </summary>
        /// <returns></returns>
        public virtual int MeasureHeight()
        {
            return 16 + Owner.ItemMargin.Vertical;
        }

        public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
        {
            if (Owner == null)
            {
                return;
            }

            Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(Owner, e.Graphics, Bounds, this));

            if (ImageVisible)
            {
                Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(Owner, e.Graphics, e.Clip, this, _imageBounds));
            }

            using (StringFormat f = StringFormatFactory.NearCenterNoWrap(StringTrimming.None))
            {
                Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(Owner, e.Graphics, Bounds, this, TextBoxTextBounds, TextBoxText.ToString(_formatString), f));

                if (LabelVisible)
                {
                    f.Alignment = (StringAlignment)TextAlignment;
                    Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(Owner, e.Graphics, Bounds, this, LabelBounds, Text, f));
                }
            }
        }

        public override void SetBounds(Rectangle bounds)
        {
            base.SetBounds(bounds);

            _textBoxBounds = Rectangle.FromLTRB(
                bounds.Right - PickerWidth,
                bounds.Top,
                bounds.Right,
                bounds.Bottom);

            if (Image != null)
            {
                _imageBounds = new Rectangle(
                    bounds.Left + Owner.ItemMargin.Left,
                    bounds.Top + Owner.ItemMargin.Top, Image.Width, Image.Height);
            }
            else
            {
                _imageBounds = new Rectangle(bounds.Location, Size.Empty);
            }

            _labelBounds = Rectangle.FromLTRB(
                _imageBounds.Right + (_imageBounds.Width > 0 ? spacing : 0),
                bounds.Top,
                _textBoxBounds.Left - spacing,
                bounds.Bottom - Owner.ItemMargin.Bottom);

            if (SizeMode == RibbonElementSizeMode.Large)
            {
                _imageVisible = true;
                _labelVisible = true;
            }
            else if (SizeMode == RibbonElementSizeMode.Medium)
            {
                _imageVisible = true;
                _labelVisible = false;
                _labelBounds = Rectangle.Empty;
            }
            else if (SizeMode == RibbonElementSizeMode.Compact)
            {
                _imageBounds = Rectangle.Empty;
                _imageVisible = false;
                _labelBounds = Rectangle.Empty;
                _labelVisible = false;
            }
        }

        public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
        {
            if (!Visible && !Owner.IsDesignMode())
            {
                SetLastMeasuredSize(new Size(0, 0));
                return LastMeasuredSize;
            }

            Size size = Size.Empty;

            int w = 0;
            int iwidth = Image != null ? Image.Width + spacing : 0;
            int lwidth = string.IsNullOrEmpty(Text) ? 0 : _labelWidth > 0 ? _labelWidth : e.Graphics.MeasureString(Text, Owner.Font).ToSize().Width + spacing;
            int twidth = PickerWidth;

            w += PickerWidth;

            switch (e.SizeMode)
            {
                case RibbonElementSizeMode.Large:
                    w += iwidth + lwidth;
                    break;
                case RibbonElementSizeMode.Medium:
                    w += iwidth;
                    break;
            }

            SetLastMeasuredSize(new Size(w, MeasureHeight()));

            return LastMeasuredSize;
        }

        public override void OnMouseEnter(MouseEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            base.OnMouseEnter(e);
            if (PickerBounds.Contains(e.Location))
            {
                Canvas.Cursor = AllowTextEdit ? Cursors.IBeam : Cursors.Default;
            }
        }

        public override void OnMouseLeave(MouseEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            base.OnMouseLeave(e);

            Canvas.Cursor = Cursors.Default;
        }

        public override void OnMouseDown(MouseEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            base.OnMouseDown(e);

            if (PickerBounds.Contains(e.X, e.Y) && _AllowTextEdit)
            {
                StartEdit();
            }
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            base.OnMouseMove(e);

            /* Hack code. Combobox SetBound function should redefine all the bounds (refer to RibbonUpDown) of the 
             * Combobox so that the there is no overlap between the textbox and dropdown. However for some reason 
             * the two controls don't work the same so the position and rendering of the Combobox end up wrong.
            */
            if (!_disableTextboxCursor)
            {
                if (PickerBounds.Contains(e.X, e.Y) && AllowTextEdit)
                {
                    Canvas.Cursor = Cursors.IBeam;
                }
                else
                {
                    Canvas.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="TextBoxTextChanged"/> event
        /// </summary>
        /// <param name="e"></param>
        public void OnTextChanged(EventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            NotifyOwnerRegionsChanged();

            if (TextBoxTextChanged != null)
            {
                TextBoxTextChanged(this, e);
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Collections.ObjectModel;
using System.Windows;

namespace NotesListBox
{
    public class NotesAdornerDecorator : AdornerDecorator
    {
        #region Data
        /// <summary>
        /// You MUST have an AdornerLayer to show the NotesListBoxControl
        /// as it was designed with the AdornerLayer in mind
        /// </summary>
        private AdornerLayer layer = null;
        /// <summary>
        /// A adorner to show the NotesListBoxControl in the AdornerLayer
        /// </summary>
        private NoteAdorner adorner = null;
        private ObservableCollection<Note> notes = new ObservableCollection<Note>();
        private FrameworkElement adornedElement;
        #endregion

        #region Ctor
        public NotesAdornerDecorator()
        {
            this.Loaded += new RoutedEventHandler(NotesAdornerDecorator_Loaded);
        }
        #endregion

        #region DPs

        /// <summary>
        /// DisplayNotes Dependency Property
        /// </summary>
        public static readonly DependencyProperty DisplayNotesProperty =
            DependencyProperty.Register("DisplayNotes", typeof(ObservableCollection<Note>), 
            typeof(NotesAdornerDecorator),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnDisplayNotesChanged)));

        /// <summary>
        /// Gets or sets the DisplayNotes property.  
        /// </summary>
        public ObservableCollection<Note> DisplayNotes
        {
            get { return (ObservableCollection<Note>)GetValue(DisplayNotesProperty); }
            set { SetValue(DisplayNotesProperty, value); }
        }

        /// <summary>
        /// Handles changes to the DisplayNotes property.
        /// </summary>
        private static void OnDisplayNotesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            NotesAdornerDecorator notesAdornerDecorator = (NotesAdornerDecorator)d;

            ((NotesAdornerDecorator)d).notes = (ObservableCollection<Note>)e.NewValue;
            
            if (notesAdornerDecorator.adorner != null & notesAdornerDecorator.layer != null)
                notesAdornerDecorator.layer.Remove(notesAdornerDecorator.adorner);

            notesAdornerDecorator.adorner = 
                new NoteAdorner(notesAdornerDecorator.adornedElement, notesAdornerDecorator.notes);
            notesAdornerDecorator.layer.Add(notesAdornerDecorator.adorner);

        }


        #endregion



        #region Private Methods

        private void NotesAdornerDecorator_Loaded(object sender, RoutedEventArgs e)
        {
            layer = this.AdornerLayer;

            //I am assuming that I need to create an actual Child element
            adornedElement = new FrameworkElement { Height = this.Height, Width = this.Width };
            this.Child = adornedElement;

            #region Wire up the actual NotesListBoxControl

            //Wire up the Close Notes Event, which will come from the 
            //NotesListBoxControl on the AdornerLayer
            EventManager.RegisterClassHandler(
                typeof(NotesListBoxControl),
                NotesListBoxControl.CloseNotesEvent,
                new EventHandler(
                    (s, ea) =>
                    {
                        if (adorner != null && layer != null)
                        {
                            layer.Remove(adorner);
                            adorner = null;
                        }
                    }));
            #endregion
        }
        #endregion

        #region Overrides
        protected override void OnRenderSizeChanged(System.Windows.SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (adornedElement != null)
            {
                adornedElement.Height = sizeInfo.NewSize.Height;
                adornedElement.Width = sizeInfo.NewSize.Width;
            }
 
            if (adorner!=null)
                adorner.ResizeToFillAvailableSpace(sizeInfo.NewSize);
        }
        #endregion
    }
}

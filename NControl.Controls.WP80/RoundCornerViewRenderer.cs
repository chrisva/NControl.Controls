﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using NControl.Abstractions;
using NControl.Controls;
using NControl.Controls.WP80;
using NControl.WP80;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(RoundCornerView), typeof(RoundCornerViewRenderer))]
namespace NControl.Controls.WP80
{
    public class RoundCornerViewRenderer : NControlViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NControlView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var element = (e.NewElement as RoundCornerView);
                UpdateElement(element);
            }
        }

        /// <summary>
        /// Raises the element property changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundCornerView.BackgroundColorProperty.PropertyName ||
                e.PropertyName == RoundCornerView.BorderColorProperty.PropertyName ||
				e.PropertyName == RoundCornerView.CornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundCornerView.BorderWidthProperty.PropertyName)
                UpdateElement(Element as RoundCornerView);
        }

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <param name="element">Element.</param>
        private void UpdateElement(RoundCornerView element)
        {
            var colorConverter = new ColorConverter();

            Border.Background = (Brush)colorConverter.Convert(element.BackgroundColor, null, null, null);
            Border.BorderBrush = (Brush)colorConverter.Convert(element.BorderColor, null, null, null);
            Border.BorderThickness = new System.Windows.Thickness(element.BorderWidth);
            Border.CornerRadius = new CornerRadius(element.CornerRadius);
        }
    }
}

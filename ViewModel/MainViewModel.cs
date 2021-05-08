using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Converter.Model;
using Converter.Repository;

namespace Converter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IValuteConverter _valuteConverter;
        private double _firstValuteField;
        private double _secondValuteField;
        private string _firstCharCodeField;
        private string _secondCharCodeField;
        private ValCurs _valutesField;
        private ValCursValute _firstSelectedValuteField;
        private ValCursValute _secondSelectedValuteField;
        private DateTime _selectedDate;
        private ValCursValute _charCodeField;
        private ValCursValute _nominalField; 
        private ushort _firstNominalField;
        private ushort _secondNominalField;




        public ushort FirstNominal
        {
            get => _firstNominalField;
            set => SetProperty(ref _firstNominalField, value, nameof(FirstNominal));
        }
        public ushort SecondNominal
        {
            get => _secondNominalField;
            set => SetProperty(ref _secondNominalField, value, nameof(SecondNominal));
        }

        public string FirstCode
        {
            get => _firstCharCodeField;
            set => SetProperty(ref _firstCharCodeField, value, nameof(FirstCode));
        }
        public string SecondCode
        {
            get => _secondCharCodeField;
            set => SetProperty(ref _secondCharCodeField, value, nameof(SecondCode));
        }
        public double FirstValute
        {
            get => _firstValuteField;
            set => SetProperty(ref _firstValuteField, value, nameof(FirstValute));
        }

        public double SecondValute
        {
            get => _secondValuteField;
            set => SetProperty(ref _secondValuteField, value, nameof(SecondValute));
        }

        public ValCursValute Nominal
        {
            get => _nominalField;
            set => SetProperty(ref _nominalField, value, nameof(Nominal));
        }
        public ValCursValute CharCode
        {
            get => _charCodeField;
            set => SetProperty(ref _charCodeField, value, nameof(CharCode));
        }
        public ValCurs Valute
        {
            get => _valutesField;
            set=> SetProperty(ref _valutesField, value, nameof(Valute));
        }

        public ValCursValute FirstSelectedValute
        {
            get => _firstSelectedValuteField;
            set
            {
                if (value == null) return;
                _firstSelectedValuteField = value;
                OnPropertyChanged(nameof(FirstSelectedValute));
                //bool result = SetProperty(ref _firstSelectedValuteField, value, nameof(FirstSelectedValute));
                //if (result == false) return;
                FirstValute = double.Parse(value.Value, CultureInfo.GetCultureInfo("ru-Ru"));
                FirstCode = value.CharCode;
                FirstNominal = value.Nominal;
            }
        }
        public ValCursValute SecondSelectedValute
        {
            get => _secondSelectedValuteField;
            set
            {
                bool result = SetProperty(ref _secondSelectedValuteField, value, nameof(SecondSelectedValute));
                if (result == false) return;
                SecondValute = double.Parse(value.Value, CultureInfo.GetCultureInfo("ru-Ru"));
                SecondCode = value.CharCode;
                SecondNominal = value.Nominal;
            } 
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set 
            {
                SetProperty(ref _selectedDate, value, nameof(SelectedDate));
                LoadView(value);
            }
    }

        public MainViewModel()
        {
            _valuteConverter = new ValutConverterImpl();
            SelectedDate = DateTime.Now;
        }

        
        private async void LoadView(DateTime? dateTime)
        {
            Valute = await _valuteConverter.GetCurse(dateTime);
            FirstSelectedValute = Valute.Valute[0];
            SecondSelectedValute = Valute.Valute[0];
        }


    }
}
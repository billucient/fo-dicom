using System;
using System.IO;

namespace Dicom.Imaging.LUT {
	public class OutputLUT : ILUT {
		#region Private Members
		private Color32[] _lut;
		#endregion

		#region Public Constructors
		public OutputLUT(Color32[] lut) {
			ColorMap = lut;
		}
		#endregion

		#region Public Properties
		public Color32[] ColorMap {
			get { return _lut; }
			set {
				if (value == null || value.Length != 256)
					throw new DicomImagingException("Expected 256 entry color map");
				_lut = value;
			}
		}

		public int MinimumOutputValue {
			get { return int.MinValue; }
		}

		public int MaximumOutputValue {
			get { return int.MaxValue; }
		}

		public bool IsValid {
			get { return _lut != null; }
		}

		public int this[int value] {
			get {
				//if (value < 0)
				//    return _table[0];
				//if (value > 255)
				//    return _table[255];
				return _lut[value].Value;
			}
		}
		#endregion

		#region Public Methods
		public void Recalculate() {
		}
		#endregion
	}
}

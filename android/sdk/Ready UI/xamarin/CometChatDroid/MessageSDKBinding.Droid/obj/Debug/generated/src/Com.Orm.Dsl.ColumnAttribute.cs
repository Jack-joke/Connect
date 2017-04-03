using System;

namespace Com.Orm.Dsl {

	[global::Android.Runtime.Annotation ("com.orm.dsl.Column")]
	public partial class ColumnAttribute : Attribute
	{
		[global::Android.Runtime.Register ("name")]
		public string Name { get; set; }

		[global::Android.Runtime.Register ("notNull")]
		public bool NotNull { get; set; }

		[global::Android.Runtime.Register ("unique")]
		public bool Unique { get; set; }

	}
}

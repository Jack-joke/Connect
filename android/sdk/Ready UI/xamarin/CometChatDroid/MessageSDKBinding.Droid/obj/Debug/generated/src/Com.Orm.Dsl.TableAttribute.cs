using System;

namespace Com.Orm.Dsl {

	[global::Android.Runtime.Annotation ("com.orm.dsl.Table")]
	public partial class TableAttribute : Attribute
	{
		[global::Android.Runtime.Register ("name")]
		public string Name { get; set; }

	}
}

; ModuleID = 'obj\Release\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Release\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [102 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 41
	i32 57263871, ; 1: Xamarin.Forms.Core.dll => 0x369c6ff => 36
	i32 134690465, ; 2: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 45
	i32 182336117, ; 3: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 33
	i32 318968648, ; 4: Xamarin.AndroidX.Activity.dll => 0x13031348 => 16
	i32 321597661, ; 5: System.Numerics => 0x132b30dd => 14
	i32 342366114, ; 6: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 27
	i32 442521989, ; 7: Xamarin.Essentials => 0x1a605985 => 35
	i32 450948140, ; 8: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 25
	i32 465846621, ; 9: mscorlib => 0x1bc4415d => 7
	i32 469710990, ; 10: System.dll => 0x1bff388e => 13
	i32 525008092, ; 11: SkiaSharp.dll => 0x1f4afcdc => 9
	i32 527452488, ; 12: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 45
	i32 627609679, ; 13: Xamarin.AndroidX.CustomView => 0x2568904f => 23
	i32 691348768, ; 14: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 47
	i32 700284507, ; 15: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 42
	i32 720511267, ; 16: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 46
	i32 809851609, ; 17: System.Drawing.Common.dll => 0x30455ad9 => 1
	i32 928116545, ; 18: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 41
	i32 956575887, ; 19: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 46
	i32 967690846, ; 20: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 27
	i32 974778368, ; 21: FormsViewGroup.dll => 0x3a19f000 => 4
	i32 1012816738, ; 22: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 32
	i32 1035644815, ; 23: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 18
	i32 1042160112, ; 24: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 38
	i32 1052210849, ; 25: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 29
	i32 1084122840, ; 26: Xamarin.Kotlin.StdLib => 0x409e66d8 => 44
	i32 1098259244, ; 27: System => 0x41761b2c => 13
	i32 1164369725, ; 28: SextantHelper => 0x4566df3d => 8
	i32 1275534314, ; 29: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 47
	i32 1293217323, ; 30: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 24
	i32 1365406463, ; 31: System.ServiceModel.Internals.dll => 0x516272ff => 49
	i32 1376866003, ; 32: Xamarin.AndroidX.SavedState => 0x52114ed3 => 32
	i32 1406073936, ; 33: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 20
	i32 1460219004, ; 34: Xamarin.Forms.Xaml => 0x57092c7c => 39
	i32 1469204771, ; 35: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 17
	i32 1562878013, ; 36: SextantHelper.Android.dll => 0x5d27a03d => 0
	i32 1592978981, ; 37: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 38: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 30
	i32 1636350590, ; 39: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 22
	i32 1639515021, ; 40: System.Net.Http.dll => 0x61b9038d => 2
	i32 1658251792, ; 41: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 40
	i32 1698840827, ; 42: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 43
	i32 1722051300, ; 43: SkiaSharp.Views.Forms => 0x66a46ae4 => 11
	i32 1729485958, ; 44: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 19
	i32 1766324549, ; 45: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 33
	i32 1776026572, ; 46: System.Core.dll => 0x69dc03cc => 12
	i32 1788241197, ; 47: Xamarin.AndroidX.Fragment => 0x6a96652d => 25
	i32 1808609942, ; 48: Xamarin.AndroidX.Loader => 0x6bcd3296 => 30
	i32 1813058853, ; 49: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 44
	i32 1813201214, ; 50: Xamarin.Google.Android.Material => 0x6c13413e => 40
	i32 1867746548, ; 51: Xamarin.Essentials.dll => 0x6f538cf4 => 35
	i32 1878053835, ; 52: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 39
	i32 1983156543, ; 53: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 43
	i32 2019465201, ; 54: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 29
	i32 2055257422, ; 55: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 28
	i32 2097448633, ; 56: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 26
	i32 2126786730, ; 57: Xamarin.Forms.Platform.Android => 0x7ec430aa => 37
	i32 2201107256, ; 58: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 48
	i32 2201231467, ; 59: System.Net.Http => 0x8334206b => 2
	i32 2279755925, ; 60: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 31
	i32 2475788418, ; 61: Java.Interop.dll => 0x93918882 => 5
	i32 2605712449, ; 62: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 48
	i32 2620871830, ; 63: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 22
	i32 2732626843, ; 64: Xamarin.AndroidX.Activity => 0xa2e0939b => 16
	i32 2737747696, ; 65: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 17
	i32 2766581644, ; 66: Xamarin.Forms.Core => 0xa4e6af8c => 36
	i32 2770495804, ; 67: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 42
	i32 2778768386, ; 68: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 34
	i32 2795602088, ; 69: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 10
	i32 2810250172, ; 70: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 20
	i32 2819470561, ; 71: System.Xml.dll => 0xa80db4e1 => 15
	i32 2853208004, ; 72: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 34
	i32 2905242038, ; 73: mscorlib.dll => 0xad2a79b6 => 7
	i32 2912489636, ; 74: SkiaSharp.Views.Android => 0xad9910a4 => 10
	i32 2927503953, ; 75: SextantHelper.dll => 0xae7e2a51 => 8
	i32 2974793899, ; 76: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 11
	i32 2978675010, ; 77: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 24
	i32 3044182254, ; 78: FormsViewGroup => 0xb57288ee => 4
	i32 3111772706, ; 79: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3247949154, ; 80: Mono.Security => 0xc197c562 => 50
	i32 3258312781, ; 81: Xamarin.AndroidX.CardView => 0xc235e84d => 19
	i32 3317135071, ; 82: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 23
	i32 3340387945, ; 83: SkiaSharp => 0xc71a4669 => 9
	i32 3353484488, ; 84: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 26
	i32 3362522851, ; 85: Xamarin.AndroidX.Core => 0xc86c06e3 => 21
	i32 3366347497, ; 86: Java.Interop => 0xc8a662e9 => 5
	i32 3374999561, ; 87: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 31
	i32 3404865022, ; 88: System.ServiceModel.Internals => 0xcaf21dfe => 49
	i32 3429136800, ; 89: System.Xml => 0xcc6479a0 => 15
	i32 3476120550, ; 90: Mono.Android => 0xcf3163e6 => 6
	i32 3536029504, ; 91: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 37
	i32 3632359727, ; 92: Xamarin.Forms.Platform => 0xd881692f => 38
	i32 3641597786, ; 93: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 28
	i32 3672681054, ; 94: Mono.Android.dll => 0xdae8aa5e => 6
	i32 3689375977, ; 95: System.Drawing.Common => 0xdbe768e9 => 1
	i32 3739362201, ; 96: SextantHelper.Android => 0xdee22399 => 0
	i32 3829621856, ; 97: System.Numerics.dll => 0xe4436460 => 14
	i32 3896760992, ; 98: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 21
	i32 3955647286, ; 99: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 18
	i32 4105002889, ; 100: Mono.Security.dll => 0xf4ad5f89 => 50
	i32 4151237749 ; 101: System.Core => 0xf76edc75 => 12
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [102 x i32] [
	i32 41, i32 36, i32 45, i32 33, i32 16, i32 14, i32 27, i32 35, ; 0..7
	i32 25, i32 7, i32 13, i32 9, i32 45, i32 23, i32 47, i32 42, ; 8..15
	i32 46, i32 1, i32 41, i32 46, i32 27, i32 4, i32 32, i32 18, ; 16..23
	i32 38, i32 29, i32 44, i32 13, i32 8, i32 47, i32 24, i32 49, ; 24..31
	i32 32, i32 20, i32 39, i32 17, i32 0, i32 3, i32 30, i32 22, ; 32..39
	i32 2, i32 40, i32 43, i32 11, i32 19, i32 33, i32 12, i32 25, ; 40..47
	i32 30, i32 44, i32 40, i32 35, i32 39, i32 43, i32 29, i32 28, ; 48..55
	i32 26, i32 37, i32 48, i32 2, i32 31, i32 5, i32 48, i32 22, ; 56..63
	i32 16, i32 17, i32 36, i32 42, i32 34, i32 10, i32 20, i32 15, ; 64..71
	i32 34, i32 7, i32 10, i32 8, i32 11, i32 24, i32 4, i32 3, ; 72..79
	i32 50, i32 19, i32 23, i32 9, i32 26, i32 21, i32 5, i32 31, ; 80..87
	i32 49, i32 15, i32 6, i32 37, i32 38, i32 28, i32 6, i32 1, ; 88..95
	i32 0, i32 14, i32 21, i32 18, i32 50, i32 12 ; 96..101
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
!llvm.linker.options = !{}

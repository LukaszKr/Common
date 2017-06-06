rmdir CoreCommon\External /s /q
mkdir CoreCommon\External
mklink /j CoreCommon\External\Common Common

rmdir NetCommon\External /s /q
mkdir NetCommon\External
mklink /j NetCommon\External\Common Common

rmdir UnityCommon\External /s /q
mkdir UnityCommon\External
mklink /j UnityCommon\External\Common Common
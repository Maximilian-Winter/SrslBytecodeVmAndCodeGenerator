﻿using MemoizeSharp.Ast;
using System.Collections.Generic;
using System.Reflection;

namespace Srsl_Parser.Runtime
{

    public class ForeignLibraryInterfaceVm : ISrslVmCallable
    {
        #region Public

        public object Call(List<DynamicSrslVariable> arguments)
        {
            if (arguments.Count > 0)
            {
                if (arguments[0].ObjectData is FastMemorySpace fliObject)
                {
                    string typeString = fliObject.Get(-1, 0, -1, 0).StringData;
                    if (!string.IsNullOrEmpty(typeString))
                    {
                        System.Type type = System.Type.GetType(typeString);
                        DynamicSrslVariable methodString = fliObject.Get(-1, 0, -1, 1);
                        if (methodString.DynamicType == DynamicVariableType.String && !string.IsNullOrEmpty(methodString.StringData))
                        {
                            List<System.Type> argTypes = new List<System.Type>();

                            if (fliObject.Get("Arguments").ObjectData is FastMemorySpace instanceTypes)
                            {
                                foreach (DynamicSrslVariable instanceProperty in instanceTypes.Properties)
                                {
                                    argTypes.Add(instanceProperty.GetType());
                                }
                            }


                            MethodInfo method = type.GetMethod(methodString.StringData, argTypes.ToArray());

                            if (method != null && method.IsStatic)
                            {
                                if (fliObject.Get("Arguments").ObjectData is FastMemorySpace instance)
                                {
                                    List<object> args = new List<object>();

                                    foreach (DynamicSrslVariable instanceProperty in instance.Properties)
                                    {
                                        args.Add(instanceProperty.ToObject());
                                    }

                                    return method.Invoke(null, args.ToArray());
                                }

                                return method.Invoke(null, null);
                            }

                            if (method != null && !method.IsStatic)
                            {
                                if (fliObject.Get("ObjectInstance") is object objectInstance)
                                {
                                    if (fliObject.Get("Arguments").ObjectData is FastMemorySpace instance)
                                    {
                                        List<object> args = new List<object>();

                                        foreach (DynamicSrslVariable instanceProperty in instance.Properties)
                                        {
                                            args.Add(instanceProperty.ToObject());
                                        }

                                        return method.Invoke(objectInstance, args.ToArray());
                                    }

                                    return method.Invoke(objectInstance, null);
                                }
                                else
                                {
                                    List<System.Type> constructorArgTypes = new List<System.Type>();

                                    if (fliObject.Get("ConstructorArguments").ObjectData is FastMemorySpace constructorInstanceTypes)
                                    {
                                        foreach (DynamicSrslVariable instanceProperty in
                                                 constructorInstanceTypes.Properties)
                                        {
                                            constructorArgTypes.Add(instanceProperty.GetType());
                                        }
                                    }

                                    List<object> constructorArgs = new List<object>();

                                    if (fliObject.Get("ConstructorArguments").ObjectData is FastMemorySpace constructorInstance)
                                    {
                                        foreach (DynamicSrslVariable instanceProperty in constructorInstance.
                                                     Properties)
                                        {
                                            constructorArgs.Add(instanceProperty.ToObject());
                                        }
                                    }

                                    ConstructorInfo constructor = type.GetConstructor(constructorArgTypes.ToArray());
                                    object classObject = constructor.Invoke(constructorArgs.ToArray());
                                    fliObject.Put("ObjectInstance", DynamicVariableExtension.ToDynamicVariable(classObject));

                                    if (fliObject.Get("Arguments").ObjectData is FastMemorySpace instance)
                                    {
                                        List<object> args = new List<object>();

                                        foreach (DynamicSrslVariable instanceProperty in instance.Properties)
                                        {
                                            args.Add(instanceProperty.ToObject());
                                        }

                                        return method.Invoke(classObject, args.ToArray());
                                    }

                                    return method.Invoke(classObject, null);
                                }
                            }
                            else
                            {
                                if (type.IsSealed && type.IsAbstract)
                                {
                                    StaticWrapper wrapper = new StaticWrapper(type);
                                    fliObject.Put("ObjectInstance", DynamicVariableExtension.ToDynamicVariable(wrapper));

                                    return wrapper;
                                }
                                else
                                {
                                    List<System.Type> constructorArgTypes = new List<System.Type>();

                                    if (fliObject.Get("ConstructorArguments").ObjectData is FastMemorySpace constructorInstanceTypes)
                                    {
                                        foreach (DynamicSrslVariable instanceProperty in constructorInstanceTypes.
                                                     Properties)
                                        {
                                            constructorArgTypes.Add(instanceProperty.GetType());
                                        }
                                    }

                                    List<object> constructorArgs = new List<object>();

                                    if (fliObject.Get("ConstructorArguments").ObjectData is FastMemorySpace constructorInstance)
                                    {
                                        foreach (DynamicSrslVariable instanceProperty in constructorInstance.
                                                     Properties)
                                        {
                                            constructorArgs.Add(instanceProperty.ToObject());
                                        }
                                    }

                                    if (constructorArgs.Count == 0)
                                    {
                                        ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
                                        object classObject = constructor.Invoke(new object[] { });
                                        fliObject.Put("ObjectInstance", DynamicVariableExtension.ToDynamicVariable(classObject));

                                        return classObject;
                                    }
                                    else
                                    {
                                        ConstructorInfo constructor = type.GetConstructor(constructorArgTypes.ToArray());
                                        object classObject = constructor.Invoke(constructorArgs.ToArray());
                                        fliObject.Put("ObjectInstance", DynamicVariableExtension.ToDynamicVariable(classObject));

                                        return classObject;
                                    }
                                }

                            }
                        }
                        else
                        {
                            if (type.IsSealed && type.IsAbstract)
                            {
                                StaticWrapper wrapper = new StaticWrapper(type);
                                fliObject.Put("ObjectInstance", DynamicVariableExtension.ToDynamicVariable(wrapper));

                                return wrapper;
                            }
                            else
                            {
                                List<System.Type> constructorArgTypes = new List<System.Type>();

                                if (fliObject.Get("ConstructorArguments").ObjectData is FastMemorySpace constructorInstanceTypes)
                                {
                                    foreach (DynamicSrslVariable instanceProperty in constructorInstanceTypes.
                                                 Properties)
                                    {
                                        constructorArgTypes.Add(instanceProperty.GetType());
                                    }
                                }

                                List<object> constructorArgs = new List<object>();

                                if (fliObject.Get("ConstructorArguments").ObjectData is FastMemorySpace constructorInstance)
                                {
                                    foreach (DynamicSrslVariable instanceProperty in constructorInstance.
                                                 Properties)
                                    {
                                        constructorArgs.Add(instanceProperty.ToObject());
                                    }
                                }

                                if (constructorArgs.Count == 0)
                                {
                                    ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
                                    object classObject = constructor.Invoke(new object[] { });
                                    fliObject.Put("ObjectInstance", DynamicVariableExtension.ToDynamicVariable(classObject));

                                    return classObject;
                                }
                                else
                                {
                                    ConstructorInfo constructor = type.GetConstructor(constructorArgTypes.ToArray());
                                    object classObject = constructor.Invoke(constructorArgs.ToArray());
                                    fliObject.Put("ObjectInstance", DynamicVariableExtension.ToDynamicVariable(classObject));

                                    return classObject;
                                }
                            }
                        }
                    }
                }

                return null;
            }

            return null;
        }

        #endregion
    }

}

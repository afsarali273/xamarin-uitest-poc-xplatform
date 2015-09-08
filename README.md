# SAMPLE X-Platfrom Mobile App Testing Framework for Xamarin UITest C# with Specflow

<span style="color:red;">**NOTE: THis is a personal project and is not an officially Xamarin template/sample. USE AT OWN RISK!!!! If you do not know what you are doing please don't use this sample. It should only be used to give you ideas for a framework specific to your app**</span> 

This project is simply a quick and messy sample of how to implement cross platform tests using UITest C#. This is no way to suggest best coding practices and principles, it is only to show the basic idea of resolving page objects for different platforms using interfaces and an IOC Container. There are other strategies for making a cross platform framework, this is just one idea and is in no way a recommendation of best practice.

##Folders (and what is in them)
* Apps : Contains the apps which the tests run against. This is a simple Xamarin forms app found on the Xamarin website. The IOS App will only run on an emulator. If you need it to run against a physical device then you will need to download the project from the Xamarin site, build and sign the app yourself.
* Pages : Has the pages objects for both IOS and Android. It also contains the interfaces which are implement by those page objects. 
* Specflow : An example implemention of x platform tests using specflow.nunit.
* Files @ project level:
  * AppManager : Contains the app instance and is in the most part responsible for managing the app.
  * Current : A simple dictionary based cache which holds values for the duration of all test fixtures in the assembly
  * PageContainer : Holds the instances of the page objects which can be resolved using the PageResolver class.
  * PageResolver : Simple static class that allows you to resolve pages from the container.
  
  
##Basic Architecture

On entry point of the code in the FeatureBase.cs the current plafrom is assigned and put into the Current cache (a cache which lasts for the duration of all tests).

```
[TestFixture(Platform.Android)]
[TestFixture(Platform.iOS)]
public class FeatureBase
{
    private Platform _platform;

    public FeatureBase(Platform platform)
    {
        _platform = platform;
    }

    [SetUp]
    public void SetUp()
    {
        Current.Platform = _platform;
    }
}
```
  
From the steps (ExampleSteps.cs) the pages are requested from the PageResolver.cs class.

```
[Given("I am on the locations page")]
public void GivenIAmOnTheLocationsPage()
{
    var page = PageResolver.HomePage().ViewLocations();
}
```

The page resolver access the public property Container in the PageContainer class. Note that the Container does not need to be directly initialised, it will do this itself based on the Current.Platform property in the Current cache.

**PageResolver.cs:**

```
private static T ResolvePage<T>() where T : IPage
{
    return PageContainer.Resolve<T>();
}

public static IHomePage HomePage()
{
    return ResolvePage<IHomePage>();
}
```

**PageContainer.cs:**

```
public static T Resolve<T>()
{
    return Container.Resolve<T>();
}

public static void DisposeContainer()
{
    Container.Dispose();
    Container = null;
}

private static IContainer Container
{
    get 
    { 
        return _container ?? Initialise();
    }
    set { _container = value; }
}

private static IContainer Initialise()
{
    var builder = new ContainerBuilder(); 
    Container = RegisterAll(builder).Build();
    return Container;
}

private static ContainerBuilder RegisterAll(ContainerBuilder builder)
{
    var prefix = Current.Platform == Platform.Android ? "And" : "IOS";

    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        .Where(i => i.Name.StartsWith(prefix) && i.Name.EndsWith("Page"))
        .AsImplementedInterfaces();  

    return builder;
}
```

Note that this implemention requires a specific naming convention of your page objects, again this is a way of doing it, there are other ways.

That is the basics of how the page objects are resolved using an IOC container and is enough to get started. 

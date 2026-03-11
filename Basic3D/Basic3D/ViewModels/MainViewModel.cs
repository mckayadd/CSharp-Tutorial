using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RobotCubeWPF.Models;
using System.Numerics;
using System.Windows.Media;
using System.Windows.Media.Media3D;


namespace RobotCubeWPF.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // Manage cube's color
    [ObservableProperty]
    private Brush _cubeColor = Brushes.Orange;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CubePositions))] // Trigger CubePositions when scale changes
    private float _scale = 1.0f; // default size

    [RelayCommand] // In xaml, bind with ChangeColorCommand. usage of RelayCommand...
    private void ChangeColor()
    {
        // Orange <-> Blue
        CubeColor = (CubeColor == Brushes.Orange) ? Brushes.SkyBlue : Brushes.Orange;
    }

    private Vector3[] _cubePositionsV3 =
    {
        new Vector3(-1, -1,  1), // Front-Bottom-Left
        new Vector3( 1, -1,  1), // Front-Bottom-Right
        new Vector3( 1,  1,  1), // Front-Top-Right
        new Vector3(-1,  1,  1), // Front-Top-Left

        new Vector3(-1, -1, -1), // Back-Bottom-Left
        new Vector3( 1, -1, -1), // Back-Bottom-Right
        new Vector3( 1,  1, -1), // Back-Top-Right
        new Vector3(-1,  1, -1), // Back-Top-Left
    };

    public Point3DCollection CubePositions
    {
        get
        {
            return new Point3DCollection(
                _cubePositionsV3.Select(v => new Point3D(v.X * Scale, v.Y * Scale, v.Z * Scale))
                );
        }
    }

    [ObservableProperty]
    private int[] _cubeIndicesA =
    {
        // Front face (Z = +1)
        0, 1, 2,
        2, 3, 0,

        // Right face (X = +1)
        1, 5, 6,
        6, 2, 1,

        // Back face (Z = -1)
        5, 4, 7,
        7, 6, 5,

        // Left face (X = -1)
        4, 0, 3,
        3, 7, 4,

        // Top face (Y = +1)
        3, 2, 6,
        6, 7, 3,

        // Bottom face (Y = -1)
        4, 5, 1,
        1, 0, 4
    };

    public Int32Collection CubeIndices =>
        new Int32Collection(_cubeIndicesA);


    public MainViewModel()
    {

    }


}

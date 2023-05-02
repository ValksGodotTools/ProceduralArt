namespace ProceduralArt;

public partial class ImageGenerator : Node
{
    private readonly Color darkBrown = new Color("342c1f");
    private readonly Color lightBrown = new Color("69593e");

    private Image image;
    private Vector2I start;

    public override void _Ready()
    {
        var textureRect = GetNode<TextureRect>("TextureRect");

        var imageSize = new Vector2I(125, 125);

        image = Image.Create(imageSize.X, imageSize.Y, true, Image.Format.Rgba8);
        image.Fill(Colors.Transparent);

        start = new Vector2I(0, imageSize.Y - 1);

        GenerateTree();

        textureRect.Texture = ImageTexture.CreateFromImage(image);
    }

    private void GenerateTree()
    {
        Trunk();
        Leaves();
    }

    private void Trunk()
    {
        var points = GetNode<Path2D>("Path2D").Curve.GetBakedPoints();

        for (int i = 0; i < points.Length - 1; i++)
        {
            var pointA = points[i];
            var pointB = points[i + 1];

            for (int a = 0; a < pointA.DistanceTo(pointB); a++)
            {
                // ?
            }

            SetPixel((int)pointA.X, (int)pointA.Y, darkBrown);
        }
    }

    private void Leaves()
    {
        
    }

    private void SetPixel(int x, int y, Color color) =>
        image.SetPixel(start.X + x, start.Y - y, color);
}

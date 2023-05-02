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
        var curve = GetNode<Path2D>("Path2D").Curve;
        curve.BakeInterval = 1;
        var points = curve.GetBakedPoints();

        for (int i = 0; i < points.Length - 1; i++)
        {
            var point = points[i];

            for (int w = 0; w < 2; w++)
                SetPixel(point.X + w, point.Y, Utils.Color(75, 65, 49));

            for (int w = 2; w < 10; w++)
                SetPixel(point.X + w, point.Y, Utils.Color(55, 48, 36));
        }
    }

    private void Leaves()
    {
        
    }

    private void SetPixel(float x, float y, Color color) =>
        image.SetPixel(start.X + (int)x, start.Y - (int)y, color);
}

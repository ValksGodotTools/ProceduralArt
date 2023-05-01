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

        var imageSize = new Vector2I(100, 100);

        image = Image.Create(imageSize.X, imageSize.Y, true, Image.Format.Rgba8);
        image.Fill(Colors.Transparent);

        start = new Vector2I(imageSize.X / 2, imageSize.Y - 1);

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
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 40; y++)
            {
                SetPixel(x, y, darkBrown);
            }
        }
    }

    private void Leaves()
    {
        
    }

    private void SetPixel(int x, int y, Color color) =>
        image.SetPixel(start.X + x, start.Y - y, color);
}

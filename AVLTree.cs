using System;
using System.Collections.Generic;
using System.Text;

class AVLTree
{
	public class b_Nodo
	{
		public int value;
		public b_Nodo left;
		public b_Nodo right;
		public b_Nodo(int valor)
		{
			value = valor;
			left = right = null;
		}
	}

	public class Tree
	{
		public b_Nodo root;

		public void Insert(b_Nodo data)
		{
			root = Insert_Recursive(root, data);
		}
		private b_Nodo Insert_Recursive(b_Nodo root, b_Nodo data)
		{
			int valor = data.value;

			if (root == null)
			{
				return data;
			}

			if (valor < root.value)
			{
				root.left = Insert_Recursive(root.left, data);
				root =Balance(root);
			}
			else
			{
				root.right = Insert_Recursive(root.right, data);
				root = Balance(root);
			}

			return root;
		}

		public void Display()
		{
			
			Display_Recursive(root,0);
			
		}
		private void Display_Recursive(b_Nodo root,int type)
		{
			if (root == null)
			{
				return;
			}
			Display_Recursive(root.left,1);
			switch (type)
			{
				case 0:
					Console.WriteLine("*");
					Console.WriteLine(root.value);
					break;

				case 1:
					Console.WriteLine("/");
					Console.WriteLine(root.value);
					break;

				case 2:
					Console.WriteLine("\\");
					Console.WriteLine(root.value);
					break;

				default:
					break;
			}
			Display_Recursive(root.right,2);
		}

		private b_Nodo Balance(b_Nodo data)
        {
			int v_factor = factor(data);
			if (v_factor > 1)
            {
				if (factor(data.left) > 0)
                {
					data = Rotate_Left_Left(data);
                }
				else
                {
					data = Rotate_Left_Right(data);
                }
            }
			else if (v_factor < -1)
			{
				if (factor(data.right) > 0)
				{
					data = Rotate_Right_Left(data);
				}
				else
				{
					data = Rotate_Right_Right(data);
				}
			}

			return data;
        }
		private int factor(b_Nodo data)
        {
			int l = getHeight(data.left);
			int r = getHeight(data.right);
			int v_factor = l - r;
			return v_factor;
		}
		private int getHeight(b_Nodo data)
        {
			int height = 0;
			if (data != null)
            {
				int l = getHeight(data.left);
				int r = getHeight(data.right);
				int m = Math.Max(l,r);
				height = m + 1;
			}
			return height;
        }
		private b_Nodo Rotate_Left_Left (b_Nodo data)
        {
			b_Nodo pivot = data.left;
			data.left = data.right;
			pivot.right = data;
			return pivot;
        }
		private b_Nodo Rotate_Left_Right(b_Nodo data)
        {
			b_Nodo pivot = data.left;
			data.left = Rotate_Right_Right(pivot);
			return Rotate_Left_Left(data);
        }
		private b_Nodo Rotate_Right_Right(b_Nodo data)
        {
			b_Nodo pivot = data.right;
			data.right = pivot.left;
			pivot.left = data;
			return pivot;
        }

		private b_Nodo Rotate_Right_Left(b_Nodo data)
        {
			b_Nodo pivot = data.right;
			data.right = Rotate_Left_Left(data);
			return Rotate_Right_Right(data);
        }

	}
}

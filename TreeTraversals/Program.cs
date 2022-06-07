using System;
using System.Collections.Generic;

//Class containing left and right child of current member contirbution
class Tree
{

    public Tree SchemeMembers { get; set; }// root
    public Tree LeftSubTree { get; set; } // contributions below 10000
    public Tree RightSubTree { get; set; } // contributions above 10000

    public int memberContributions { get; set; }
}

class BinaryTree
{
    public Tree SchemeMembers { get; set; }
    public BinaryTree()
    {
        SchemeMembers = null;
    }
    
    public void AddContribution(int contributions)
    {
        Tree newContribution = new Tree();

        newContribution.memberContributions = contributions;

        if (SchemeMembers == null)
        {
            SchemeMembers = newContribution;
        }
        else
        {
            Tree current = SchemeMembers;
            Tree parent;
            while (true)
            {
                parent = current;

                if (contributions < current.memberContributions)
                {
                    current = current.LeftSubTree;
                    if (current == null)
                    {
                        parent.LeftSubTree = newContribution;
                        return;
                    }
                }

                else
                {
                    current = current.RightSubTree;
                    if (current == null)
                    {
                        parent.RightSubTree = newContribution;
                        return;
                    }
                }
            }
        }
    }
    public void PrintPretty(string indent, bool last)
    {
        Console.Write(indent);
        if (last)
        {
            Console.Write("\\-");
            indent += "  ";
        }
        else
        {
            Console.Write("|-");
            indent += "| ";
        }
        Console.WriteLine(SchemeMembers);
  
    }
    static void Main(String[] args)
    {
        try
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.AddContribution(1100);
            binaryTree.AddContribution(20000);
            binaryTree.AddContribution(3500);
            binaryTree.AddContribution(4100);
            binaryTree.AddContribution(1135);
            binaryTree.AddContribution(50600);
            binaryTree.AddContribution(75000);
            binaryTree.AddContribution(18000);
            binaryTree.AddContribution(4008);
            binaryTree.AddContribution(11900);
            binaryTree.AddContribution(51700);

            Console.WriteLine("PreOrder Traversal:\n");
            binaryTree.PreOrderTraversal(binaryTree.SchemeMembers);
            Console.WriteLine(" ");
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:\n");
            binaryTree.PostOrderTraversal(binaryTree.SchemeMembers);
            Console.WriteLine(" ");
            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:\n");
            binaryTree.InorderTraversal(binaryTree.SchemeMembers);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.ReadKey();
        }
        catch (Exception)
        {

            throw;
        }
    }
   public void PreOrderTraversal(Tree parent)
    {
        if (parent != null)
        {
            Console.Write(parent.memberContributions + " ");
            PreOrderTraversal(parent.LeftSubTree);
            PreOrderTraversal(parent.RightSubTree);
        }
    }

    //Inorder traversal
    public void InorderTraversal(Tree parent)
    {
        if (parent != null)
        {
            InorderTraversal(parent.LeftSubTree);
            Console.Write(parent.memberContributions + " ");
            InorderTraversal(parent.RightSubTree);
        }
    }


    //Post order traversal

    public void PostOrderTraversal(Tree parent)
    {
        if (parent != null)
        {
            PostOrderTraversal(parent.LeftSubTree);
            PostOrderTraversal(parent.RightSubTree);
            Console.Write(parent.memberContributions + " ");
        }
    }
}
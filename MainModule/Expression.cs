using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public delegate float CallOperate(float num0, float num1);

interface IExpressionNode
{
    float GetResult();
    bool IsNumber { get; }
}

public class ExpressionNode : IExpressionNode
{
    protected bool IsNum;

    public virtual float GetResult()
    {
        return 0;
    }

    public bool IsNumber => IsNum;
}

public class ExpressionNumNode : ExpressionNode
{
    public float Data { get;}
    

    public ExpressionNumNode(float data)
    {
        Data = data;
        IsNum = true;
    }

    public override float GetResult() => Data;

    public override string ToString()
    {
        return Data.ToString();
    }
}

public class ExpressionOperateNode : ExpressionNode
{
    public char Data { get; }

    public ExpressionNode Node0 { get; set; }
    public ExpressionNode Node1 { get; set; }

    private CallOperate CallOperate;
    public ExpressionOperateNode Parent = null;

    public ExpressionOperateNode(char data, ExpressionNode node0, ExpressionNode node1)
    {
        IsNum = false;
        Node0 = node0;
        Node1 = node1;
        Data = data;
        switch (data)
        {
            case '+':
                CallOperate = BasicCalculator.Plus;
                break;
            case '-':
                CallOperate = BasicCalculator.Minus;
                break;
            case '*':
                CallOperate = BasicCalculator.Multiply;
                break;
            case '/':
                CallOperate = BasicCalculator.Divide;
                break;
            default:
                throw new BasicCalculatorException("错误的符号!");
        }
    }
    
    public override float GetResult() => CallOperate(Node0.GetResult(), Node1.GetResult());

    public override string ToString()
    {
        return Data.ToString();
    }

    public bool HasParent() => Parent != null;

}

public class ExpressionTree : IEnumerable,IEnumerator
{
    public float Result { get; private set; }
    public string exp;

    private List<ExpressionNode> _numNodes = new List<ExpressionNode>();
    private List<ExpressionNode> _operatorNodes = new List<ExpressionNode>();

    private int _position = -1;
    private static string _highLevelOperator = "*/";
    private static string _lowLevelOperator = "+-";
    private static string _bracket = "()";
    private ExpressionOperateNode _root;

    public ExpressionTree(string expr)
    {
        try
        {
            exp = expr;
            _root = GenerateExpressionTree(expr);
            Calculate();
        }
        catch (Exception e)
        {
            throw new BasicCalculatorException("输入的表达式有误！");
        }
        
    }

    private void Calculate() => Result = _root.GetResult();

    #region 生成表达式树

    private ExpressionOperateNode GenerateExpressionTree(string expr)
    {
        StringBuilder tmp = new StringBuilder();
        ExpressionNode curLeafNode = null;
        ExpressionOperateNode curOperatorNode = null;
        bool ForceUp = false;
        expr = expr + ".";
        for (int i = 0; i < expr.Length; i++)
        {
            if (IsNum(expr[i]))
            {
                tmp.Append(expr[i]);
            }
            else
            {
                if (tmp.Length != 0)
                {
                    float num = float.Parse(tmp.ToString());
                    tmp.Clear();
                    curLeafNode = new ExpressionNumNode(num);
                    _numNodes.Add(curLeafNode);
                    if (curOperatorNode != null)
                    {
                        curOperatorNode.Node1 = curLeafNode;
                    }
                }

                if(ForceUp && curOperatorNode!=null)
                {
                    curOperatorNode.Node1 = curLeafNode;
                }

                if (IsOperator(expr[i]))
                {
                    var tmpOperateNode = new ExpressionOperateNode(expr[i], curLeafNode, null);
                    if (curLeafNode != null && !curLeafNode.IsNumber)
                        ((ExpressionOperateNode) curLeafNode).Parent = tmpOperateNode;
                    _operatorNodes.Add(tmpOperateNode);
                    if (IsHighOperator(expr[i]) && curOperatorNode != null)
                    {
                        PushDown(curOperatorNode, tmpOperateNode);
                    }
                    else if ((IsLowOperator(expr[i]) && curOperatorNode != null) || (ForceUp && curOperatorNode != null))
                    {
                        PushUp(curOperatorNode, tmpOperateNode);
                        if (ForceUp) ForceUp = false;
                    }

                    curOperatorNode = tmpOperateNode;
                }
                else
                {
                    if (!IsBracket(expr[i]) || expr[i] != '(') continue;
                    curLeafNode = GenerateExpressionTree(expr.Substring(i+1, SearchMatchBracket(expr, i) - i - 1 ));
                    i = SearchMatchBracket(expr, i) ;
                    if (curOperatorNode != null)
                    {
                        curOperatorNode.Node1 = curLeafNode;
                        if (curLeafNode != null && !curLeafNode.IsNumber)
                            ((ExpressionOperateNode)curLeafNode).Parent = curOperatorNode;
                    }
                    ForceUp = true;
                }
            }
        }

        return GetRoot(curOperatorNode);
    }



    private void PushUp(ExpressionOperateNode preNode, ExpressionOperateNode curNode)
    {
        var tmpNode = GetRoot(preNode);
        curNode.Node0 = tmpNode;
        tmpNode.Parent = curNode;
    }

    private void PushDown(ExpressionOperateNode preNode, ExpressionOperateNode curNode)
    {
        curNode.Node0 = preNode.Node1;
        preNode.Node1 = curNode;
        curNode.Parent = preNode;
    }

    private ExpressionOperateNode GetRoot(ExpressionOperateNode node)
    {
        while (node!=null && node.HasParent()) node = node.Parent;
        return node;
    }

    #endregion

    #region 检查符号

    private bool IsBracket(char ch) => _bracket.Contains(ch.ToString());

    private bool IsNum(char ch) =>
        !(_highLevelOperator.Contains(ch.ToString()) || _lowLevelOperator.Contains(ch.ToString()) ||
          _bracket.Contains(ch.ToString()) || ch == '.');

    private bool IsOperator(char ch) =>
        (_highLevelOperator.Contains(ch.ToString()) || _lowLevelOperator.Contains(ch.ToString()));

    private bool IsHighOperator(char ch) => _highLevelOperator.Contains(ch.ToString());

    private bool IsLowOperator(char ch) => _lowLevelOperator.Contains(ch.ToString());

    private int SearchMatchBracket(string exp,int startIndex)
    {
        int leftCount = 0;
        for (int i = startIndex; i < exp.Length; i++)
        {
            if (exp[i] == '(') leftCount++;
            if (exp[i] == ')')
            {
                leftCount--;
                if (leftCount == 0) return i;
            }
        }

        return -1;
    }

    #endregion

    #region 枚举器

    public IEnumerator GetEnumerator()
    {
        return this as IEnumerator;
    }

    public bool MoveNext()
    {
        if (_position < _numNodes.Count + _operatorNodes.Count - 1)
        {
            _position++;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current
    {
        get
        {
            if(_position==-1)
                throw new InvalidOperationException();
            if(_position > _numNodes.Count + _operatorNodes.Count + 2) 
                throw new InvalidOperationException();

            return _position % 2 == 0 ? _numNodes[_position / 2] : _operatorNodes[(_position - 1)/2];
        }
    }

    #endregion
}


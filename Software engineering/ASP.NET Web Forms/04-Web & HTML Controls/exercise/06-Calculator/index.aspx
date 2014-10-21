<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_06_Calculator.index" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/04-style-calculator.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <p class="desc">Make a simple Web Calculator. The calculator should support the operations like addition, subtraction, multiplication, division and square root. Validation is essential!</p>

        <div class="calculator">
		<div class="cacl-icon"></div>
		<div class="titleCalc">
			<span class="title-text"> Calculator</span>
		</div>
		<div class="navigation">
			<nav>
				<ul>
					<li>View</li>
					<li>Edit</li>
					<li>Help</li>
				</ul>
			</nav>
		</div>
		<div class="calculator-content">
			<form class="form1" name="form1" method="post">
				<div class="input-field">
					<input type="text" id="result" runat="server" value="0">
				</div>
				<div class="bit">
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div class="byte-1">0000</div>
						<div class="byte-2">36</div>
						<div class="byte-1">0000</div>
						<div class="byte-2">31</div>
					</div>
					<div class="clear"></div>
				</div>
				<table border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td colspan="2" rowspan="3">
							<div class="leftGroupStyle">
								<label> <input type="radio" name="NumSys" value="hex"
									class="NumSys_0"> Hex
								</label> <br> <label> <input type="radio" checked="checked"   
									name="NumSys" value="Dec" class="NumSys_1"> Dec
								</label> <br> <label> <input type="radio" name="NumSys" 
									value="Oct" class="NumSys_2"> Oct
								</label> <br> <label> <input type="radio" name="NumSys" 
									value="Bin" class="NumSys_3"> Bin
								</label> <br>
							</div>
						</td>
						<td><button class="btnStyle2"></button></td>
						<td><button class="btnStyleOne">Mod</button></td>
						<td><button class="btnStyle2">A</button></td>
						<td><button class="btnStyle2">MC</button></td>
						<td><button class="btnStyle2">MR</button></td>
						<td><button class="btnStyle2">MS</button></td>
						<td><button class="btnStyle2">M+</button></td>
						<td><button class="btnStyle2">M-</button></td>
					</tr>
					<tr>
						<td><button class="btnStyleOne">(</button></td>
						<td><button class="btnStyleOne">)</button></td>
						<td><button class="btnStyle2">B</button></td>
						<td><button class="btnStyleOne">&#8592;</button></td>
						<td><button class="btnStyleOne">CE</button></td>
						<td><button class="btnStyleOne">C</button></td>
						<td><button class="btnStyleOne">&#177</button></td>
						<td><button class="btnStyle2">&#8730;</button></td>
					</tr>
					<tr>
						<td><button class="btnStyleOne">Rol</button></td>
						<td><button class="btnStyleOne">RoR</button></td>
						<td><button class="btnStyle2">C</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn7" OnServerClick="ClickBtn">7</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn8" OnServerClick="ClickBtn">8</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn9" OnServerClick="ClickBtn">9</button></td>
						<td><button class="btnStyleOne" runat="server" id="btnDevide" OnServerClick="ClickBtn">/</button></td>
						<td><button class="btnStyle2">%</button></td>
					</tr>
					<tr>
						<td colspan="2" rowspan="3">
							<div class="leftGroupStyle">
								<label> <input type="radio" name="RadioWordGroup"
									checked="checked" value="Qword" class="RadioWordGroup_0">
									Qword
								</label> <br> <label> <input type="radio"
									name="RadioWordGroup" value="Dword" class="RadioWordGroup_1">
									Dword
								</label> <br> <label> <input type="radio"
									name="RadioWordGroup" value="Word" class="RadioWordGroup_2">
									Word
								</label> <br> <label> <input type="radio"
									name="RadioWordGroup" value="Byte" class="RadioWordGroup_3">
									Byte
								</label> <br>
							</div>
						</td>
						<td><button class="btnStyleOne">Or</button></td>
						<td><button class="btnStyleOne">XoR</button></td>
						<td><button class="btnStyle2">D</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn4" OnServerClick="ClickBtn">4</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn5" OnServerClick="ClickBtn">5</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn6" OnServerClick="ClickBtn">6</button></td>
						<td><button class="btnStyleOne" runat="server" id="btnmult" OnServerClick="ClickBtn">*</button></td>
						<td><button class="btnStyle2">1/x</button></td>
					</tr>
					<tr>
						<td><button class="btnStyleOne">Lsh</button></td>
						<td><button class="btnStyleOne">Rsh</button></td>
						<td><button class="btnStyle2">E</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn1" OnServerClick="ClickBtn">1</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn2" OnServerClick="ClickBtn">2</button></td>
						<td><button class="btnStyleOne" runat="server" id="btn3" OnServerClick="ClickBtn">3</button></td>
						<td><button class="btnStyleOne" runat="server" id="btnSubstract" OnServerClick="ClickBtn">-</button></td>
						<td rowspan="2"><button class="btnStyle3">=</button></td>
					</tr>
					<tr>
						<td><button class="btnStyleOne">Not</button></td>
						<td><button class="btnStyleOne">And</button></td>
						<td><button class="btnStyle2">F</button></td>
						<td colspan="2"><button class="btnStyle4" runat="server" id="btn0" OnServerClick="ClickBtn">0</button></td>
						<td><button class="btnStyle2" runat="server" id="btnPoint" OnServerClick="ClickBtn">.</button></td>
						<td><button class="btnStyleOne" runat="server" id="btnSum" OnServerClick="ClickBtn">+</button></td>
					</tr>
				</table>
			</form>
		</div>
	</div>

    </div>
    </form>
</body>
</html>

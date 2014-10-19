﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_06_Calculator.index" %>

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

        <div id="calculator">
		<div class="cacl-icon"></div>
		<div id="titleCalc">
			<span class="title-text"> Calculator</span>
		</div>
		<div id="navigation">
			<nav>
				<ul>
					<li>View</li>
					<li>Edit</li>
					<li>Help</li>
				</ul>
			</nav>
		</div>
		<div id="calculator-content">
			<form id="form1" name="form1" method="post">
				<div id="input-field">
					<input type="text" value="8854455">
				</div>
				<div id="bit">
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div class="bitSection">
						<div id="byte-1">0000</div>
						<div id="byte-2">36</div>
						<div id="byte-1">0000</div>
						<div id="byte-2">31</div>
					</div>
					<div id="clear"></div>
				</div>
				<table border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td colspan="2" rowspan="3">
							<div id="leftGroupStyle">
								<label> <input type="radio" name="NumSys" value="hex"
									id="NumSys_0"> Hex
								</label> <br> <label> <input type="radio" checked="checked"
									name="NumSys" value="Dec" id="NumSys_1"> Dec
								</label> <br> <label> <input type="radio" name="NumSys"
									value="Oct" id="NumSys_2"> Oct
								</label> <br> <label> <input type="radio" name="NumSys"
									value="Bin" id="NumSys_3"> Bin
								</label> <br>
							</div>
						</td>
						<td><button id="btnStyle2"></button></td>
						<td><button id="btnStyleOne">Mod</button></td>
						<td><button id="btnStyle2">A</button></td>
						<td><button id="btnStyle2">MC</button></td>
						<td><button id="btnStyle2">MR</button></td>
						<td><button id="btnStyle2">MS</button></td>
						<td><button id="btnStyle2">M+</button></td>
						<td><button id="btnStyle2">M-</button></td>
					</tr>
					<tr>
						<td><button id="btnStyleOne">(</button></td>
						<td><button id="btnStyleOne">)</button></td>
						<td><button id="btnStyle2">B</button></td>
						<td><button id="btnStyleOne">&#8592;</button></td>
						<td><button id="btnStyleOne">CE</button></td>
						<td><button id="btnStyleOne">C</button></td>
						<td><button id="btnStyleOne">&#177</button></td>
						<td><button id="btnStyle2">&#8730;</button></td>
					</tr>
					<tr>
						<td><button id="btnStyleOne">Rol</button></td>
						<td><button id="btnStyleOne">RoR</button></td>
						<td><button id="btnStyle2">C</button></td>
						<td><button id="btnStyleOne">7</button></td>
						<td><button id="btnStyleOne">8</button></td>
						<td><button id="btnStyleOne">9</button></td>
						<td><button id="btnStyleOne">/</button></td>
						<td><button id="btnStyle2">%</button></td>
					</tr>
					<tr>
						<td colspan="2" rowspan="3">
							<div id="leftGroupStyle">
								<label> <input type="radio" name="RadioWordGroup"
									checked="checked" value="Qword" id="RadioWordGroup_0">
									Qword
								</label> <br> <label> <input type="radio"
									name="RadioWordGroup" value="Dword" id="RadioWordGroup_1">
									Dword
								</label> <br> <label> <input type="radio"
									name="RadioWordGroup" value="Word" id="RadioWordGroup_2">
									Word
								</label> <br> <label> <input type="radio"
									name="RadioWordGroup" value="Byte" id="RadioWordGroup_3">
									Byte
								</label> <br>
							</div>
						</td>
						<td><button id="btnStyleOne">Or</button></td>
						<td><button id="btnStyleOne">XoR</button></td>
						<td><button id="btnStyle2">D</button></td>
						<td><button id="btnStyleOne">4</button></td>
						<td><button id="btnStyleOne">5</button></td>
						<td><button id="btnStyleOne">6</button></td>
						<td><button id="btnStyleOne">*</button></td>
						<td><button id="btnStyle2">1/x</button></td>
					</tr>
					<tr>
						<td><button id="btnStyleOne">Lsh</button></td>
						<td><button id="btnStyleOne">Rsh</button></td>
						<td><button id="btnStyle2">E</button></td>
						<td><button id="btnStyleOne">1</button></td>
						<td><button id="btnStyleOne">2</button></td>
						<td><button id="btnStyleOne">3</button></td>
						<td><button id="btnStyleOne">-</button></td>
						<td rowspan="2"><button id="btnStyle3">=</button></td>
					</tr>
					<tr>
						<td><button id="btnStyleOne">Not</button></td>
						<td><button id="btnStyleOne">And</button></td>
						<td><button id="btnStyle2">F</button></td>
						<td colspan="2"><button id="btnStyle4">0</button></td>
						<td><button id="btnStyle2">.</button></td>
						<td><button id="btnStyleOne">+</button></td>
					</tr>
				</table>
			</form>
		</div>
	</div>

    </div>
    </form>
</body>
</html>

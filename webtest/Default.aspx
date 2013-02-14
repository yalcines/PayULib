<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webtest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PayU Ödeme Test</title>
    <script src="https://secure.payu.com.tr/openpayu/v2/client/jquery-1.7.2.js"></script>		
		<script src="https://secure.payu.com.tr/openpayu/v2/client/json2.js"></script>	
    <script src="https://secure.payu.com.tr/openpayu/v2/client/openpayu-2.0.js"></script>
    <script src="https://secure.payu.com.tr/openpayu/v2/client/plugin-payment-2.0.js"></script>
    <script src="https://secure.payu.com.tr/openpayu/v2/client/plugin-installment-2.0.js"></script>
		<!--  Style class for preloader -->
		<link rel="stylesheet"  type="text/css" href="https://secure.payu.com.tr/openpayu/v2/client/openpayu-builder-2.0.css">		

		<style type="text/css">
			.card {
				width:200px;
				height: 20px;
				border:1px solid #CCC;
				margin: 1px;
				padding: 1px;
				font-size: 16px;
			}
		</style>
</head>
	<body>
		<h1>OpenPayU JS+API Implementaion</h1>
		<h2>Test cards:</h2>
		<p>card no: 4022774022774026<br/>
		exp: 12/2012<br/>
		cvv: 000</p>
		
		<p>card no: 4508034508034509<br/>
		exp: 12/2012<br/>
		cvv: 000</p>

		<p>card no: 4355084355084358 (for 3dSecure)<br/>
		exp: 12/2012<br/>
		cvv: 000</p>

		
		
		<p>Card program: <span id="card-program"></p>
		<p>Error message: <span id="error"></p>

			

		<form action="" method="post">
			<table>
			<tr>
					<td>Product name</td>
					<td><input type="text" style="width:400px" id="description"></td>
				</tr>			

				<tr>
					<td>Amount (TRY)</td>
					<td><input type="text" id="amount"></td>
				</tr>
								
				<tr>
					<td>First Name</td>
					<td><input type="text" id="first_name"></td>
				</tr>
				<tr>
					<td>Last Name</td>
					<td><input type="text" id="last_name"></td>
				</tr>
				<tr>
					<td>Email</td>
					<td><input type="text" id="email"></td>
				</tr>
				<tr>
					<td>Phone</td>
					<td><input type="text" id="phone"></td>
				</tr>		
				
				<tr>
					<td>Name</td>
					<td><div id="payu-card-cardholder-placeholder" class="card" ></div></td>
				</tr>			
				<tr>
					<td>Card number</td>
					<td><div id="payu-card-number-placeholder" class="card" ></div></td>				
				</tr>
				<tr>
					<td>Card cvv</td>
					<td><div id="payu-card-cvv-placeholder" class="card" ></div></td>				
				</tr>
				<tr>
					<td>Expiration month</td>
					<td><input type="text"  class="card"  id="payu-card-expm"></td>				
				</tr>
				<tr>
					<td>Expiration year</td>
					<td><input type="text"  class="card"  id="payu-card-expy"></td>
				</tr>									
				<tr>
					<td>Installment no</td>
					<td><input type="text"  class="card"  id="payu-card-installment"></td>				
				</tr>									
				<tr>
					<td><input type="submit" id="payu-cc-form-submit"></td>
				</tr>
			</table>
		</form>


		<script>


		  $(function () {

		    //**********************************************************
		    //installment setup 
		    //**********************************************************

		    //used to control some stuff when card program is change
		    OpenPayU.Installment.onCardChange(function (data) { //optional
		      //data.program - Axess, Bonus, Maximum, Advantage, CardFinans, World
		      $('#card-program').html(JSON.stringify(data.program));
		    });

		    //**********************************************************
		    //payment setup
		    //**********************************************************
		    OpenPayU.Payment.setup({ id_account: "OPU_TEST", orderCreateRequestUrl: "ocr.aspx" });


		    $('#payu-cc-form-submit').click(function () {



		      //add preloader
		      OpenPayU.Builder.addPreloader('Please wait ... ');

		      //**********************************************************
		      //begin payment 
		      //**********************************************************
		      OpenPayU.Payment.create({
		        //merchant can send to his server side script other additional data from page. (OPTIONAL)
		        orderCreateRequestData: {
		          Email: $('#email').val(),
		          FirstName: $('#first_name').val(),
		          LastName: $('#last_name').val(),
		          Amount: $('#amount').val(),
		          Description: $('#description').val(),
		          Phone: $('#phone').val(),
		          Currency: 'TRY'
		        }
		      }, function (response) {
		        //console.log(typeof response.OrderCreateResponse);
		        //update buyer experience
		        if (typeof response.OrderCreateResponse != "undefined") {
		          if (response.OrderCreateResponse.Status.StatusCode == 'OPENPAYU_SUCCESS') {
		            alert('Thank for payment.' + '\n' + JSON.stringify(response));
		          }
		        } else {
		          alert('An error ocured.');
		          //$('#error').html(response.status + '\n' + JSON.stringify(response) );
		        }

		        //remove preloader
		        OpenPayU.Builder.removePreloader();
		        return false;
		      });
		      return false;
		    });
		  } ());

		</script>

	</body>
</html>

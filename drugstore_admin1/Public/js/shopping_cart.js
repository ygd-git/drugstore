/* 
* @Author: anchen
* @Date:   2017-04-05 19:15:24
* @Last Modified by:   anchen
* @Last Modified time: 2017-04-07 10:14:37
*/

$(document).ready(function(){
    var
        form = $('#settlement-form'),
        products = form.find('.product'),
        selectAll = form.find('label.selectAll :checkbox'),
        selectAllLabel = form.find('label.selectAll span.selectAll'),
        deselectAllLabel = form.find('label.selectAll span.deselectAll'),
        invertSelect = form.find('a.invertSelect'),
        trs = $('form tbody tr');

    // 重置初始化状态:
    form.find('*').show().off();
    form.find(':checkbox').prop('checked', false).off();
    deselectAllLabel.hide();
    // 拦截form提交事件:
    form.off().submit(function (e) {
        //
        //alert(form.serialize());
        var address = $('input[name=address]').val(),
        phone = $('input[name=phone]').val(),
        count = count_price();
        

        if (address && phone && products.filter(':checked').length > 0) {
        	return confirm('请确认你的收货地址:'+address+'\n'+'手机号'+phone+'\n'+'总金额:'+count);
        }else{
            e.preventDefault();
        	alert('请填写完整收货地址和手机号还有选中要结算的商品!');
        }
        
    });    
    //计算总金额
    //form 提交
    
    function count_price() {
		var products_check = products.filter(':checked'),
		rst = 0;
      	products_check.map(function(index,elem){
      		var jq_this = $(this),
      		money_count = jq_this.parentsUntil('tbody').filter('tr').find('td.money');

      		
      		rst += parseFloat(money_count.text().substring(1));
      	})
      	return rst;
        
    }
    function updateLabel(){
      var allChecked = products.filter(':checked').length === products.length;
      selectAll.prop('checked',allChecked);
      if(allChecked){
          selectAllLabel.hide()
          deselectAllLabel.show()
      }else{
          selectAllLabel.show()
          deselectAllLabel.hide()
      }
    }
    selectAll.change(function(e){
        products.prop('checked',$(this).is(':checked'));
        if ($(this).is(':checked')) {
            trs.addClass('active');
        }else{
            trs.removeClass('active');
        }
        
        updateLabel();
    });

    invertSelect.click(function(e){
        products.click();
    });
    products.change(updateLabel);

    products.click(function(event) {
        var jq_product = $(this);
        trs.map(function(index, elem) {
            var product = $(this).find('input.product');
            if (product.is(':checked')) {
                $(this).addClass('active');
            }else{
                $(this).removeClass('active');
            }
        })
    });
    
    
    var moneys = form.find('td.money');
    moneys.map(function(index, elem) {
        var jq_money = $(this),
        price = jq_money.parent().find('td.price'),
        num = jq_money.prev('td').find('input'),
        numVal = num.val(),
        priceVal =  price.text();
        priceVal = priceVal.substring(0,priceVal.length-1);
        
        try{
            numVal = parseInt(numVal);
            priceVal = parseFloat(priceVal);
            money_text = numVal*priceVal;
            //console.log(money_text);
            jq_money.text('¥'+money_text);

        }catch(e){
            console.log(e);
        }
    })



    var numSpans = form.find('.input-group-addon');


    numSpans.map(function(index, elem) {
        var jq_numSpan = $(this);

        jq_numSpan.click(function(event) {
            var num = jq_numSpan.parent('div').find('input'),            
            numVal = num.val(),
            money = jq_numSpan.parent().parent().next('td.money'),
            price = jq_numSpan.parent().parent().prev('td.price'),    
            priceVal =  price.text();
            priceVal = priceVal.substring(0,priceVal.length-1);
            console.log(priceVal);
            if (!numVal) {
                numVal=0;
            };   
            try{
                    numVal = parseInt(numVal);
                    priceVal = parseFloat(priceVal);
                    console.log(numVal);
                    if (jq_numSpan.hasClass('addNum')) {
                        numVal = numVal+1;
                    }else{
                        if (numVal!==0) {
                            numVal = numVal-1;
                                 
                        }  
                    }
                    
                    num.val(numVal);  
                    var totalPrice =  priceVal*numVal;
                    money.text('¥'+totalPrice);
                }
                catch(e){
                    console.log(e);
                }

            });
    });


    
    //console.log(count_price());
});
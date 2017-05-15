/* 
* @Author: anchen
* @Date:   2017-04-04 23:36:31
* @Last Modified by:   anchen
* @Last Modified time: 2017-04-05 16:39:33
*/

$(document).ready(function(){
    var num = $('form#buy_form input[name=goods_num]');
    var addSpan = $('form#buy_form #addNum');
    var reduceSpan = $('form#buy_form #reduceNum');
    console.log(addSpan);
    addSpan.click(function(event) {
        var numVal = num.val();
        if (!numVal) {
            numVal=0;
        };
        try{
            numVal = parseInt(numVal);
            console.log(numVal);
            num.val(numVal+1);
        }catch(e){
            console.log(e);
        }
    });
    reduceSpan.click(function(event) {
        var numVal = num.val();
        if (!numVal) {
            numVal=0;
        };
        try{
            numVal = parseInt(numVal);
            console.log(numVal);
            if (numVal!==0) {
                num.val(numVal-1);        
            }
            
        }catch(e){
            console.log(e);
        }
    });
    num.keydown(function(event) {
        return (event.keyCode>=48&&event.keyCode<=57||event.keyCode===32||event.keyCode===8);
    });
});
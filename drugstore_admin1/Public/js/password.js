/* 
* @Author: anchen
* @Date:   2017-04-14 19:51:20
* @Last Modified by:   anchen
* @Last Modified time: 2017-04-14 19:55:03
*/

$(document).ready(function(){
    var password_form =  $('form#password_form');

        password_form.submit(function(e){
            var old_password = password_form.find('[name=old_password]').val();
            var password = password_form.find('[name=password]').val();
            var password_confirm = password_form.find('[name=password_confirm]').val();
            

            if (old_password && password_confirm && password) {
                if (password_confirm === password) {
                    //可以提交了
                }
                else{
                    e.preventDefault();
                    alert('俩次密码输入不一致!');
                }
                
            }else{
                e.preventDefault();
                alert('请填写完整');
            }
            
        });
});
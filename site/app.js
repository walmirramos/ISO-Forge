const modes={equilibrado:{icon:'icons/equilibrado.png',tag:'REMOÇÕES PREDEFINIDAS',title:'Menos aplicativos. Recursos preservados.',description:'Reduza aplicativos e componentes com um conjunto de remoções predefinidas. Windows Update, Microsoft Defender e recuperação são mantidos.',warning:'Confira as remoções: alguns aplicativos dependem de componentes como WebView2.'},minimo:{icon:'icons/minimo.png',tag:'APENAS PARA TESTES ISOLADOS',title:'Uma imagem menor. Com limites claros.',description:'Reduza ainda mais o repositório de componentes. O modo Mínimo remove o suporte a manutenção e recuperação e desativa o Microsoft Defender.',warning:'Use apenas em máquinas virtuais isoladas. Não conte com atualizações, recursos ou idiomas adicionados depois.'},personalizado:{icon:'icons/personalizado.png',tag:'VOCÊ ESCOLHE OS COMPONENTES',title:'Escolha o que entra. E o que fica de fora.',description:'Comece sem seleções e escolha grupos ou componentes individuais. Revise cada descrição, as dependências e o resumo antes de criar a ISO.',warning:'Remoções avançadas podem afetar a segurança e impedir a inicialização. Teste o resultado em uma máquina virtual.'}};
const tabs=[...document.querySelectorAll('[data-mode]')];
function selectMode(tab){const mode=modes[tab.dataset.mode];tabs.forEach(t=>{const selected=t===tab;t.setAttribute('aria-selected',String(selected));t.tabIndex=selected?0:-1});document.getElementById('mode-icon').src=mode.icon;for(const key of ['tag','title','description','warning'])document.getElementById('mode-'+key).textContent=mode[key];document.getElementById('mode-panel').setAttribute('aria-labelledby',tab.id)}
tabs.forEach((tab,index)=>{tab.addEventListener('click',()=>selectMode(tab));tab.addEventListener('keydown',event=>{let next;if(event.key==='ArrowRight')next=(index+1)%tabs.length;else if(event.key==='ArrowLeft')next=(index+tabs.length-1)%tabs.length;else if(event.key==='Home')next=0;else if(event.key==='End')next=tabs.length-1;else return;event.preventDefault();selectMode(tabs[next]);tabs[next].focus()})});


const splitInput=document.getElementById('theme-split');
const comparison=document.querySelector('.theme-compare');
const viewButtons=[...document.querySelectorAll('[data-view]')].filter(el=>el.tagName==='BUTTON');
function updateSplit(value){comparison.style.setProperty('--split',value+'%');splitInput.setAttribute('aria-valuetext',value+'% tema claro e '+(100-value)+'% tema escuro');}
splitInput.addEventListener('input',()=>updateSplit(Number(splitInput.value)));
viewButtons.forEach(button=>button.addEventListener('click',()=>{
 const view=button.dataset.view;comparison.dataset.view=view;
 viewButtons.forEach(item=>item.setAttribute('aria-pressed',String(item===button)));
 const value=view==='claro'?100:view==='escuro'?0:Number(splitInput.value);
 updateSplit(value);
 document.getElementById('theme-help').textContent=view==='comparar'?'Capturas reais · arraste a divisão para comparar.':'Captura real do aplicativo · tema '+view+'.';
}));
const previewDialog=document.getElementById('preview-dialog');
const expandedShot=document.getElementById('expanded-shot');
const expandedButtons=[...document.querySelectorAll('[data-expanded-theme]')];
function showExpandedTheme(theme){expandedShot.src='images/tema-'+theme+'.png';expandedShot.alt='Captura ampliada do ISO Forge no tema '+theme;expandedButtons.forEach(button=>button.setAttribute('aria-pressed',String(button.dataset.expandedTheme===theme)));}
document.getElementById('expand-preview').addEventListener('click',()=>{showExpandedTheme(comparison.dataset.view==='escuro'?'escuro':'claro');previewDialog.showModal();});
document.getElementById('close-preview').addEventListener('click',()=>previewDialog.close());
expandedButtons.forEach(button=>button.addEventListener('click',()=>showExpandedTheme(button.dataset.expandedTheme)));
previewDialog.addEventListener('click',event=>{if(event.target===previewDialog){const box=previewDialog.getBoundingClientRect();if(event.clientX<box.left||event.clientX>box.right||event.clientY<box.top||event.clientY>box.bottom)previewDialog.close();}});

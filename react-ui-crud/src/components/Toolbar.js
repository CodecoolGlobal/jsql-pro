import React from 'react';
import Tippy from '@tippyjs/react';
import 'tippy.js/dist/tippy.css';


class Toolbar extends React.Component {


    render() {
        return <div class="toolbar">
            <Tippy content="error messages" placement='bottom'>
            <button>1</button>
            </Tippy>
            <button>2</button>
            <button>3</button>
            <button>4</button>
            <button>5</button>
        </div>

    }
}

export default Toolbar;
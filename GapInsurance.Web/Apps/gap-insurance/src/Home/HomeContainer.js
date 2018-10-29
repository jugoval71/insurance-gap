import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as homeActions from './../actions/home';
import Home from './Home';

const mapStateToProps = (state) => {
    return ({
        home: state.insurance.home
    });
};

const mapDispatchToProps = (dispatch) => {
    return ({
        actions: {
            home: bindActionCreators(homeActions, dispatch),
        }
    });
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Home);